using Kaizen.Business.Interface;
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

using Newtonsoft.Json;
namespace Kaizen.Web.Controllers
{
    public class LoginController : Controller
    {
        public IHttpContextAccessor conAccessor;
        private readonly ILogin _loginworker;
        private readonly IWebHostEnvironment _environment;
        List<ManagerModel> ManagerList = new List<ManagerModel>();

       

        public LoginController(ILogin _loginworker, IHttpContextAccessor conAccessor)
        {
            this._loginworker = _loginworker;
            this.conAccessor = conAccessor; 
        }

        [HttpGet]
        public IActionResult Index()
        {

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

                            if (HttpContext != null && HttpContext.Session != null)
                           {
                                HttpContext.Session.SetString("Message",Username);
                                HttpContext.Session.SetString("EmpId", EmpId);

                                HttpContext.Session.SetString("Department", row["DepartmentName"].ToString());
                                HttpContext.Session.SetString("Domain", row["DomainName"].ToString());
                                HttpContext.Session.SetString("UserID", row["ID"].ToString());
                                //HttpContext.Session.SetString("Manager", row["ManagerName"].ToString());
                                HttpContext.Session.SetString("IEemail", row["IEEMAIL"].ToString());
                                HttpContext.Session.SetString("Userrole", row["Userrole"].ToString());

                                HttpContext.Session.SetString("FinanceEmail", row["FinanceEmail"].ToString());
                                HttpContext.Session.SetString("ManagerList", ManagerListJson);

                            }
                            //string manager = conAccessor.HttpContext.Session.GetString("Manager");
                            Response.Redirect("Admin/Adduser");
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
        public IActionResult Logout()
        {
            conAccessor.HttpContext.Session.GetString("Message");
           

            
            if (HttpContext.Session.IsAvailable)
            {
                HttpContext.Session.Clear();
            }
            return RedirectToAction("Index", "Login", new { area = "" });
        }


        
    }
}
