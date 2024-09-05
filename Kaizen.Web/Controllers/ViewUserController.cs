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
                LogEvents.LogToFile(DbFiles.Title, ex.ToString()); 
            }

            return View(viewModel);
        }
        public IActionResult ViewFilterUser(string? Name, string? EmpId, string? Email, string? UserType, string? Domain, string? Department)
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
                return PartialView("_UserGridPartial", userList);
            }
            catch (Exception ex)
            {
                // Log the exception with a descriptive message
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return PartialView("_UserGridPartial", new List<UserGridModel>()); // Return an empty list in case of an error
            }
        }

        public List<DepartmentModel> FetchDepartment(string domainid)
        {
            List<DepartmentModel> deptList = new List<DepartmentModel>();
            try
            {
                if (!string.IsNullOrEmpty(domainid))
                {
                    deptList = _departmentWorker.GetDepartments()
                          .Where(m => m.DomainId == Convert.ToInt32(domainid) && m.Status == true)  // Adjust based on how 'active' is represented
                          .ToList();
                }
            }
            catch (Exception ex)
            {
                // Log the exception with a descriptive message
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());

            }

            return deptList;
        }
      
        public IActionResult DeleteUser(int id)
        {
            bool deleteStatus = false;
            try
            {
                ViewUserallModel viewModel = new ViewUserallModel();

                deleteStatus = _viewUserWorker.DeleteUser(id);
                if (deleteStatus)
                {

                }
            }
            catch (Exception ex)
            {
                // Log the exception with a descriptive message
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return RedirectToAction("ViewUser");

        }

        [HttpPost]
        public string Upload(IFormFile file, string Status, string UserType, string Password)
        {
            string resultMessage = string.Empty;

            try
            {
                if (file == null || file.Length == 0)
                {
                    return "No file uploaded.";
                }
                 resultMessage = _viewUserWorker.SendFile(file, Status, UserType, Password);
            }
            catch (Exception ex)
            {
                // Log the exception with a descriptive message
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                // Return a generic error message
                resultMessage = "An error occurred while uploading the file.";
            }

            return resultMessage;
        }

        public IActionResult ViewUserByDomainID(int? domainId, string? Name, string? EmpId, string? Email, string? UserType, string? Domain, string? Department)
        {
            ViewUserallModel viewModel = new ViewUserallModel();
            try
            {
                // Fetch the user types
                viewModel.UserTypeList = _addUserWorker.GetUserType();

                // Fetch and filter domains (if needed)
                viewModel.DomainList = _domainWorker.GetDomain().Where(d => d.Status == true).ToList();

                // Get users based on the domainId if provided
                if (domainId.HasValue)
                {
                    viewModel.UsergridList = _viewUserWorker.GetUsersByDomainId(domainId.Value);
                }
                //else
                //{
                //    viewModel.UsergridList = new List<User>();
                //}

                viewModel.StatusList = _viewUserWorker.GetStatus();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }

            return View("/Views/ViewUser/ViewUser.cshtml", viewModel);
        }

        public IActionResult ViewUserByDeptID(int? domainId, int? departmentId, string? Name, string? EmpId, string? Email, string? UserType, string? Domain, string? Department)
        {
            ViewUserallModel viewModel = new ViewUserallModel();
            try
            {
                // Fetch the user types
                viewModel.UserTypeList = _addUserWorker.GetUserType();

                // Fetch and filter domains (if needed)
                viewModel.DomainList = _domainWorker.GetDomain().Where(d => d.Status == true).ToList();

                // Get users based on the domainId and departmentId if provided
                if (domainId.HasValue && departmentId.HasValue)
                {
                    viewModel.UsergridList = _viewUserWorker.GetUsersByDeptId(domainId.Value, departmentId.Value);
                }
                else if (domainId.HasValue)
                {
                    viewModel.UsergridList = _viewUserWorker.GetUsersByDomainId(domainId.Value);
                }
                else
                {
                    viewModel.UsergridList = new List<UserGridModel>(); // Empty list if no domainId or departmentId is provided
                }

                viewModel.StatusList = _viewUserWorker.GetStatus();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }

            return View("/Views/ViewUser/ViewUser.cshtml", viewModel);
        }


        public IActionResult ViewUserByBlockID(int? blockId)
        {
            ViewUserallModel viewModel = new ViewUserallModel();
            try
            {
                // Fetch the user types
                viewModel.UserTypeList = _addUserWorker.GetUserType();

                // Fetch domains if needed (e.g., for a dropdown or filter)
                viewModel.DomainList = _domainWorker.GetDomain().Where(d => d.Status == true).ToList();

                // Get users based on the blockId if provided
                if (blockId.HasValue)
                {
                    viewModel.UsergridList = _viewUserWorker.GetUsersByBlockId(blockId.Value);
                }
                else
                {
                    viewModel.UsergridList = new List<UserGridModel>();
                }

                viewModel.StatusList = _viewUserWorker.GetStatus();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }

            return View("/Views/ViewUser/ViewUser.cshtml", viewModel);
        }
    }
}
