using Kaizen.Business.Interface;
using Kaizen.Data.Constant;
using Microsoft.AspNetCore.Session;
using Kaizen.Models.AdminModel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Http;
namespace Kaizen.Web.Controllers
{
    public class LoginController : Controller
    {
        public IHttpContextAccessor conAccessor;
        private readonly ILogin _loginworker;
        private readonly IWebHostEnvironment _environment;

        public LoginController(ILogin _loginworker, IHttpContextAccessor conAccessor)
        {
            this._loginworker = _loginworker;
            this.conAccessor = conAccessor;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind] LoginModel loginmodel)
        {
            string EmpId, password,Username;
            DataTable dataTable = new DataTable();
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
                        if (EmpId == loginmodel.EmpId && password == loginmodel.Password)
                        {
                           String Id= conAccessor.HttpContext.Session.Id;
                           if(HttpContext != null && HttpContext.Session != null)
                            {
                                Response.Redirect("Admin/Adduser");
                                HttpContext.Session.SetString("Message",Username);
                            }
                         
                                
                        }
                        else
                        {
                            TempData["msg"] = "Entered password Wrong";
                        }

                    }
                    else { TempData["msg"] = "User Not present with Id: " + loginmodel.EmpId; }
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
            return RedirectToAction("Index");
        }
    }
}
