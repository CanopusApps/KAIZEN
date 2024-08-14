using Kaizen.Business.Interface;
using Kaizen.Data.Constant;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Xml.Linq;
using Kaizen.Web;
using System.Reflection.Metadata;
using Kaizen.Models.ViewUserModel;
using Kaizen.Models.AdminModel;
using Kaizen.Business.Worker;
using static System.Reflection.Metadata.BlobBuilder;

namespace Kaizen.Web.Controllers
{
    public class ViewUserController : Controller
    {
        private readonly IViewuser _viewUserWorker;
		private readonly IAddUser _addUserWorker;
        private readonly IDomain _domainWorker;
        private readonly IDepartment   _departmentWorker;
		private readonly IWebHostEnvironment _environment;
        public ViewUserController(IViewuser viewUserWorker, IAddUser addUserWorker, IDomain domainWorker,IDepartment departmentWorker)
        {
			_viewUserWorker = viewUserWorker;
			_addUserWorker = addUserWorker;
            _domainWorker = domainWorker;
            _departmentWorker = departmentWorker;
        }

        //Created by Manas 
        public IActionResult ViewUser(string? Name, string? EmpId, string? Email, string? UserType, string? Domain, string? Department)
        {
            ViewUserallModel viewModel = new ViewUserallModel();
            try
            {
                viewModel.UserTypeList = _addUserWorker.GetUserType();

				viewModel.DomainList = _domainWorker.GetDomain().Where(d => d.Status == true).ToList();
                UserGridModel model = new UserGridModel()
                {
                    Name = Name,
                    EmpID = EmpId,
                    Email = Email,
                    UserType = UserType,
                    Domain = Domain,
                    Department = Department
                };
				viewModel.UsergridList = _viewUserWorker.GetUser(model);
                viewModel.StatusList = _viewUserWorker.GetStatus();
            }
            catch (Exception ex) {
                //LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment); 
            }

            return View(viewModel);
        }
        public IActionResult ViewFilterUser(string? Name, string? EmpId, string? Email, string? UserType, string? Domain, string? Department)
        {
            UserGridModel model = new UserGridModel()
            {
                Name = Name,
                EmpID = EmpId,
                Email = Email,
                UserType = UserType,
                Domain = Domain,
                Department = Department
            };
            var userList = _viewUserWorker.GetUser(model);
            return PartialView("_UserGridPartial", userList);
        }

        public List<DepartmentModel> FetchDepartment(string domainid)
        {
            List<DepartmentModel> deptList = new List<DepartmentModel>();
            if (!string.IsNullOrEmpty(domainid))
            {
                deptList = _departmentWorker.GetDepartments()
                      .Where(m => m.DomainId == Convert.ToInt32(domainid) && m.Status == true)  // Adjust based on how 'active' is represented
                      .ToList();
            }
            return deptList;
        }
      
        public IActionResult DeleteUser(int id)
        {
            bool deleteStatus = false;
            ViewUserallModel viewModel = new ViewUserallModel();

            deleteStatus = _viewUserWorker.DeleteUser(id);
            if (deleteStatus)
            {

            }

            return RedirectToAction("ViewUser");

        }

        [HttpPost]
        public string Upload(IFormFile file, string Status, string UserType, string Password)
        {
            var Return = "";
            if (file == null || file.Length == 0)
            {
                return "No file uploaded.";
            }
            Return=_viewUserWorker.SendFile(file,Status,UserType,Password);
            return Return;
        }
        
    }
}
