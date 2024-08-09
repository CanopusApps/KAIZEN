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
namespace Kaizen.Web.Controllers
{
    public class LoginController : Controller
    {
        public IHttpContextAccessor conAccessor;
        private readonly ILogin _loginworker;
        private readonly IWebHostEnvironment _environment;

        private readonly IForgotPassword _forgotPasswordWorker;

        private readonly IThemeChanger _addThemeWorker;

        List<ManagerModel> ManagerList = new List<ManagerModel>();
        List<CountModel> CountList = new List<CountModel>();

        public LoginController(ILogin _loginworker, IHttpContextAccessor conAccessor, IThemeChanger _addThemeWorker, IForgotPassword forgotPasswordWorker)
        {
            this._loginworker = _loginworker;
            this.conAccessor = conAccessor;
            this._addThemeWorker = _addThemeWorker;
            this._forgotPasswordWorker = forgotPasswordWorker;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ThemeModel model = new ThemeModel();
            List<ThemeModel> RetrieveTheme = new List<ThemeModel>();
            try
            {
                RetrieveTheme = _addThemeWorker.RetrieveTheme();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            ViewBag.ThemeList = RetrieveTheme;
            if (RetrieveTheme.Any())
            {
                ViewBag.SelectedTheme = RetrieveTheme.First().Theme;
                HttpContext.Session.SetString("SelectedTheme",RetrieveTheme.First().Theme);

            }


            return View();

        }
        [HttpPost]
        public IActionResult Index([Bind] LoginModel loginmodel)
        {
            string EmpId, password,Username,userRole;
            string Domainname, departmentname;
            DataTable dataTable = new DataTable();
            DataTable dataTable1 = new DataTable();
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

                        if (EmpId == loginmodel.EmpId && password == loginmodel.Password)
                        {
                            //dataTable1 = _loginworker.Usermanager(EmpId);
                            List<Claim> claims = new List<Claim>();
                            claims.Add(new Claim(ClaimTypes.NameIdentifier, EmpId));
                            claims.Add(new Claim(ClaimTypes.Name, Username));
                            claims.Add(new Claim(ClaimTypes.Role, userRole));

                            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                            HttpContext.SignInAsync(claimsPrincipal);

                            String Id= conAccessor.HttpContext.Session.Id;

                            ManagerList = _loginworker.Usermanager(EmpId);
                            var ManagerListJson = JsonConvert.SerializeObject(ManagerList);

                            CountList= _loginworker.FetchCount();
                            var CountListJson = JsonConvert.SerializeObject(CountList);

                            if (HttpContext != null && HttpContext.Session != null)
                           {
                                HttpContext.Session.SetString("Message",Username);
                                HttpContext.Session.SetString("EmpId", EmpId);

                                HttpContext.Session.SetString("Department", row["DepartmentName"].ToString());
                                HttpContext.Session.SetString("Domain", row["DomainName"].ToString());
                                HttpContext.Session.SetString("UserID", row["ID"].ToString());

                                // Image approver is true or false
                                HttpContext.Session.SetString("ImageApprover", row["ImageApprover"].ToString());
                                //HttpContext.Session.SetString("Manager", row["ManagerName"].ToString());
                                HttpContext.Session.SetString("IEemail", row["IEEMAIL"].ToString());
                                HttpContext.Session.SetString("Userrole", row["Userrole"].ToString());                             
                               HttpContext.Session.SetString("FinanceEmail", row["FinanceEmail"].ToString());

                               
                                HttpContext.Session.SetString("ManagerList", ManagerListJson);
                                HttpContext.Session.SetString("CountList", CountListJson);

                            }
                            string Userrole = conAccessor.HttpContext.Session.GetString("Userrole");
                            string ImageApprover = conAccessor.HttpContext.Session.GetString("ImageApprover");// if True user is image Approver (store's "True" or"")
                            if (Userrole == "ADMIN")
                            {
                                Response.Redirect("Dashboard/Dashboardtab1");
                            }
                            else if(Userrole == "EMPLOYEE")
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
            catch (Exception)
            {
                return BadRequest("Invalid or expired link.");
            }

            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(LoginModel model)
        {
            bool stat= false;
            if (ModelState.IsValid)
            {
                stat = _forgotPasswordWorker.UpdatePassword(model);
                return View(model);
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
            String userEmail = _forgotPasswordWorker.FetchEmail(id);
            if (string.IsNullOrEmpty(userEmail))
            {
                return NotFound("User email not found.");
            }
            string subject = "Password Reset Request";
            DateTime linkGeneratedTime = DateTime.UtcNow; //Generating Timestamp
            string resetLink = Url.Action("ResetPassword", "Login", new { data = $"{id}|{linkGeneratedTime}" }, protocol: HttpContext.Request.Scheme);
            string body = $"Please reset your password by clicking on this link: <a href='{resetLink}'>Reset Password</a>";

            SendEmail(userEmail, subject, body);

            return Ok(true);
        }
        //private void SendEmail(string toEmail, string subject, string body)
        //{
        //    SmtpClient client = new SmtpClient("smtp.gmail.com")
        //    {
        //        Port = 587, 
        //        Credentials = new NetworkCredential("sudhan.manuel30@gmail.com", "keen rajl ogjp jibz"),
        //        EnableSsl = true,
        //    };

        //    MailMessage mailMessage = new MailMessage
        //    {
        //        From = new MailAddress("sudhan.manuel30@gmail.com"),
        //        Subject = subject,
        //        Body = body,
        //        IsBodyHtml = true,
        //    };
        //    mailMessage.To.Add(toEmail);
        //    client.Send(mailMessage);
        //}
        private void SendEmail(string toEmail, string subject, string body)
        {
            SmtpClient client = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("sudhan.manuel@canopusgbs.com", "Sudhan30#"),
                EnableSsl = true,
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("sudhan.manuel@canopusgbs.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(toEmail);
            client.Send(mailMessage);
        }



        public IActionResult Logout()
        {
          
           

            
            if (HttpContext.Session.IsAvailable)
            {
                HttpContext.Session.Clear();
            }
            return RedirectToAction("Index", "Login", new { area = "" });
        }

        public IActionResult ErrorPage()
        {
               return View();
        }
    }
}
