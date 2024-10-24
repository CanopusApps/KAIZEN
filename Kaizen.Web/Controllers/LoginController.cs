﻿using Kaizen.Business.Interface;
using Kaizen.Data.Constant;
using Microsoft.AspNetCore.Session;
using Kaizen.Models.AdminModel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Kaizen.Data.DataServices.Interfaces;



//Forgot Password
using System.Net;
using System.Net.Mail;

using Newtonsoft.Json;
using Kaizen.Models.Theme;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Text;
using Kaizen.Business.Worker;
namespace Kaizen.Web.Controllers
{
    public class LoginController : Controller
    {
        public IHttpContextAccessor conAccessor;
        private readonly ILogin _loginworker;
        private readonly IWebHostEnvironment _environment;

        private readonly IForgotPassword _forgotPasswordWorker;

        private readonly IThemeChanger _addThemeWorker;
        private readonly IConfiguration _configuration;

        List<ManagerModel> ManagerList = new List<ManagerModel>();
        List<CountModel> CountList = new List<CountModel>();
        string hashedPassword;

        public LoginController(ILogin _loginworker, IHttpContextAccessor conAccessor, IThemeChanger _addThemeWorker, IForgotPassword forgotPasswordWorker, IConfiguration configuration)
        {
            this._loginworker = _loginworker;
            this.conAccessor = conAccessor;
            this._addThemeWorker = _addThemeWorker;
            this._forgotPasswordWorker = forgotPasswordWorker;
            this._configuration = configuration;

        }

        [HttpGet]
        public IActionResult Index()
        {
          
            try
            {
               
                var activeTheme = _addThemeWorker.GetActiveTheme(DateTime.Now);

                // If an active theme is found, set it to the session
                if (activeTheme != null)
                {

                    HttpContext.Session.SetString("SelectedTheme", activeTheme.Theme);
                    HttpContext.Session.SetString("StartDate", activeTheme.StartDate?.ToString("MMMM dd") ?? string.Empty);
                    HttpContext.Session.SetString("EndDate", activeTheme.EndDate?.ToString("MMMM dd") ?? string.Empty);
                }
                else
                {

                    HttpContext.Session.Remove("SelectedTheme");
                    HttpContext.Session.Remove("StartDate");
                    HttpContext.Session.Remove("EndDate");
                }
                // Set ViewBag to access the theme in the view
                ViewBag.SelectedTheme = HttpContext.Session.GetString("SelectedTheme"); // Default value if null
                ViewBag.StartDate = HttpContext.Session.GetString("StartDate");
                ViewBag.EndDate = HttpContext.Session.GetString("EndDate");
            }

            
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
          
            return View();

        }
        [HttpPost]
        public IActionResult Index([Bind] LoginModel loginmodel)
        {


           
            string EmpId, password,Username,userRole,userRolecode;
            string Domainname, departmentname;
            DataTable dataTable = new DataTable();
            DataTable dataTable1 = new DataTable();
            ModelState.Remove(nameof(loginmodel.ConfirmPassword));
            try
            {
                if (ModelState.IsValid)
                {
                    dataTable = _loginworker.Loginuser(loginmodel);
                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];
                        EmpId = row["EmpId"].ToString();
                        password = row["Password"].ToString();
                        Username= row["FirstName"].ToString();
                        userRole = row["UserRole"].ToString();
                        userRolecode = row["UserRolecode"].ToString();


                        //using (SHA256 sha256 = SHA256.Create())
                        //{
                        //    byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(loginmodel.Password));
                        //    StringBuilder hashPasswordBuilder = new StringBuilder();
                        //    foreach (byte b in hashValue)
                        //    {
                        //        hashPasswordBuilder.Append(b.ToString("x2"));
                        //    }
                        //    hashedPassword = hashPasswordBuilder.ToString();
                        //}

                        //if (EmpId == loginmodel.EmpId && password == hashedPassword)
                        if (EmpId == loginmodel.EmpId && password == loginmodel.Password)
                        {
                            //dataTable1 = _loginworker.Usermanager(EmpId);
                            List<Claim> claims = new List<Claim>();
                            claims.Add(new Claim(ClaimTypes.NameIdentifier, EmpId));
                            claims.Add(new Claim(ClaimTypes.Name, Username));
                            claims.Add(new Claim(ClaimTypes.Role, userRolecode));

                            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                            HttpContext.SignInAsync(claimsPrincipal);

                            String Id= conAccessor.HttpContext.Session.Id;

                            ManagerList = _loginworker.Usermanager(EmpId);
                            //here login data saving
                             _loginworker.USERLOGIN(EmpId);
                            var ManagerListJson = JsonConvert.SerializeObject(ManagerList);


                            if (HttpContext != null && HttpContext.Session != null)
                           {
                                HttpContext.Session.SetString("Message",Username);
                                HttpContext.Session.SetString("EmpId", EmpId);

                                HttpContext.Session.SetString("Department", row["DepartmentName"].ToString());
                                HttpContext.Session.SetString("Domain", row["DomainName"].ToString());
                                HttpContext.Session.SetString("UserID", row["ID"].ToString());
                                HttpContext.Session.SetString("DepartmentId", row["DepartmentID"].ToString());

                                // Image approver is true or false
                                HttpContext.Session.SetString("ImageApprover", row["ImageApprover"].ToString());
                                //HttpContext.Session.SetString("Manager", row["ManagerName"].ToString());
                                HttpContext.Session.SetString("IEemail", row["IEEMAIL"].ToString());
                                HttpContext.Session.SetString("Userrole", row["userRolecode"].ToString());                             
                               HttpContext.Session.SetString("FinanceEmail", row["FinanceEmail"].ToString());

                               
                                HttpContext.Session.SetString("ManagerList", ManagerListJson);

                            }
                            string Userrole = conAccessor.HttpContext.Session.GetString("Userrole");
                            string ImageApprover = conAccessor.HttpContext.Session.GetString("ImageApprover");// if True user is image Approver (store's "True" or"")
                            if (Userrole == "ADM")
                            {
                                Response.Redirect("Dashboard/Dashboardtab1");
                            }
                            else if(Userrole == "EMP")
                            {
                                Response.Redirect("Dashboard/EmployeeDashboard");
                            }
                            else
                            {
                                Response.Redirect("Dashboard/Dashboardothers");
                            }
                        }
                        else
                        {
                            TempData["loginmsg"] = "Entered password Wrong";
                        }

                    }
                    else { TempData["loginmsg"] = "User Not present with Id: " + loginmodel.EmpId; }
                }
               
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }


            return View();
        }
        public IActionResult ResetPassword(string data)
        {
            try
            {
                string[] parts = data.Split('|');
                if (parts.Length != 2)
                {
                    return BadRequest("Invalid link format.");
                }

                string userId = parts[0];
                DateTime linkGeneratedTime = DateTime.Parse(parts[1]);

                // Check if the link is within the 30-minute validity period
                if (DateTime.UtcNow - linkGeneratedTime > TimeSpan.FromMinutes(30))
                {
                    return BadRequest("The link has expired.");
                }

                // Pass the userId to the view
                ViewData["UserId"] = userId;
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }

            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(LoginModel model)
        {
            bool stat= false;
            try
            {
                if (ModelState.IsValid)
                {
                    stat = _forgotPasswordWorker.UpdatePassword(model);
                    return View(model);
                } 
            }
            catch (Exception ex)
            {
                // Log the exception to a file or another logging mechanism
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
              
            }
            return View(stat);
        }
        public IActionResult Forgot()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Forgot(string id)
        {
            try
            {
                String userEmail = _forgotPasswordWorker.FetchEmail(id);
                if (string.IsNullOrEmpty(userEmail))
                {
                    return Ok(false);
                }
                string subject = "Password Reset Request";
                DateTime linkGeneratedTime = DateTime.UtcNow; //Generating Timestamp
                string resetLink = Url.Action("ResetPassword", "Login", new { data = $"{id}|{linkGeneratedTime}" }, protocol: HttpContext.Request.Scheme);
                string body = $"Please reset your password by clicking on this link: <a href='{resetLink}'>Reset Password</a>";

                SendEmail(userEmail, subject, body);
                return Ok(true);
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return StatusCode(500, "An error occurred while processing your request. Please try again later.");

            }

        }
        private void SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                var emailSettings = _configuration.GetSection("EmailSettings");

                SmtpClient client = new SmtpClient(emailSettings["SmtpServer"])
                {
                    Port = int.Parse(emailSettings["Port"]),
                    Credentials = new NetworkCredential(emailSettings["Username"], emailSettings["Password"]),
                    EnableSsl = bool.Parse(emailSettings["EnableSsl"])
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(emailSettings["FromEmail"]),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(toEmail);
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
        }



        public IActionResult Logout()
        {
            try
            {
                _loginworker.USERLOGOUT(HttpContext.Session.GetString("EmpId"));

                if (HttpContext.Session.IsAvailable)
                {
                    HttpContext.Session.Clear();
                }
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());

                // Optionally, return an error view or redirect to an error page
                return RedirectToAction("Error", "Home");  // Assuming you have an Error action in HomeController
            }
          
        }

        public IActionResult ErrorPage()
        {
               return View();
        }
        [HttpGet]
        public IActionResult GetSerializedCountList()
        {
            try
            {
                var countList = _loginworker.FetchCount();
                var countListJson = JsonConvert.SerializeObject(countList);
                return Json(countListJson);
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());

                return Json(new { error = "An error occurred while fetching the count list." });
            }
        }


        public IActionResult loginImage(LoginWinnerListModel images)
        {
          
            try
            {
                // Fetch all images, including all categories
                images.CompletewinnerList = _loginworker.FetchImages();

                // Initialize the lists based on categories from CompletewinnerList
                images.GoldList = images.CompletewinnerList.Where(img => img.Category == "Gold").ToList();
                images.SilverList = images.CompletewinnerList.Where(img => img.Category == "Silver").ToList();
                images.BronzeList = images.CompletewinnerList.Where(img => img.Category == "Bronze").ToList();
                images.ThemeList = images.CompletewinnerList.Where(img => img.Category == "Theme").ToList();

                return Ok(images);
            }
            catch (Exception ex)
            {

                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return Ok(images);
        }

    }
}
