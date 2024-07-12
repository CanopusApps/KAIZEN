using Kaizen.Business.Interface;
using Kaizen.Data.Constant;
using Microsoft.AspNetCore.Session;
using Kaizen.Models.AdminModel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Http;
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

        private readonly IProfile _profileworker;
        ProfileModel model = new ProfileModel();

        public LoginController(ILogin _loginworker, IHttpContextAccessor conAccessor, IProfile profile)
        {
            this._loginworker = _loginworker;
            this.conAccessor = conAccessor;
            _profileworker = profile; 
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind] LoginModel loginmodel)
        {
            string EmpId, password,Username;
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
                        HttpContext.Session.SetString("Department", row["DepartmentName"].ToString());
                        HttpContext.Session.SetString("Domain", row["DomainName"].ToString());
                        HttpContext.Session.SetString("UserID", row["ID"].ToString());
                        //HttpContext.Session.SetString("Manager", row["ManagerName"].ToString());
                        HttpContext.Session.SetString("IEemail", row["IEEMAIL"].ToString());
                        HttpContext.Session.SetString("FinanceEmail", row["FinanceEmail"].ToString());
                        if (EmpId == loginmodel.EmpId && password == loginmodel.Password)
                        {
                            //dataTable1 = _loginworker.Usermanager(EmpId);
                            String Id= conAccessor.HttpContext.Session.Id;
                           if(HttpContext != null && HttpContext.Session != null)
                           {
                                Response.Redirect("Admin/Adduser");
                                HttpContext.Session.SetString("Message",Username);
                                HttpContext.Session.SetString("EmpId", EmpId);
                               
                              
                            }
                            //string manager = conAccessor.HttpContext.Session.GetString("Manager");
                            ManagerList= _loginworker.Usermanager(EmpId);
                            var ManagerListJson = JsonConvert.SerializeObject(ManagerList);
                            HttpContext.Session.SetString("ManagerList", ManagerListJson);
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


        public IActionResult Profile()
        {
            try
            {
                //model.EmpID = conAccessor.HttpContext.Session.Id;
                //model.EmpID =;

                //model = _profile.UserProfile(model);

                //the following code assigns null string to EmpID
                //model.EmpID = loginModel.EmpId;
                //model.EmpID = conAccessor.HttpContext.Session.GetString("EmpId");
                string empid = conAccessor.HttpContext.Session.GetString("EmpId");

                //object not set to an instance of an object
                //model = _profile.UserProfile(model.EmpID);

                //model = _profile.UserProfile(empid); 
                model = _profileworker.UserProfile(empid);
                
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateProfile()
        {
            return View(model);
        }
    }
}
