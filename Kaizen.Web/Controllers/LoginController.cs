using Kaizen.Business.Interface;
using Kaizen.Data.Constant;
using Kaizen.Models.AdminModel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
namespace Kaizen.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin _loginworker;
        private readonly IWebHostEnvironment _environment;

        public LoginController(ILogin _loginworker)
        {
            this._loginworker = _loginworker;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind] LoginModel loginmodel)
        {
            string EmpId, password;
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
                        if (EmpId == loginmodel.EmpId && password == loginmodel.Password)
                        {

                            Response.Redirect("Admin/AddDepartment");

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
                LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment);
                return View();
            }


            return View();
        }
    }
}
