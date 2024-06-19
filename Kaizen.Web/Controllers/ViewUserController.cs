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

				viewModel.DomainList = _domainWorker.GetDomain();
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
        public JsonResult ViewFilterUser(string? Name, string? EmpId, string? Email, string? UserType, string? Domain, string? Department)
        {
            try
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
                return Json(userList);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                // LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment); 
                return Json(new { success = false, message = ex.Message });
            }
        }
        public List<DepartmentModel> FetchDepartment(string domainid)
        {
            List<DepartmentModel> deptList = new List<DepartmentModel>();
            if (!string.IsNullOrEmpty(domainid))
            {
				deptList = _departmentWorker.GetDepartments().Where(d=>d.DomainId == Convert.ToInt32(domainid)).ToList();                

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
    }
}
