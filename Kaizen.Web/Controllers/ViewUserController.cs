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
        //public List<UserTypeModel> UserTypeList()
        //{
        //    List<UserTypeModel> list = new List<UserTypeModel>();
        //    UserTypeModel model = new UserTypeModel();
        //    DataTable dt = new DataTable();
        //    model.flag = "get";
        //    DataSet ds = _user.GetUserType(model);
        //    if (ds.Tables.Count > 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            list.Add(new UserTypeModel
        //            {
        //                UserTypeId = Convert.ToInt16(dr["UserTypeId"]),
        //                UserDesc = dr["UserDesc"].ToString()
        //            });
        //        }
        //    }
        //    return list;
        //}
        //public List<DomainModel> DomainList()
        //{

        //    List<DomainModel> list = new List<DomainModel>();
        //    DomainModel model = new DomainModel();
        //    DataTable dt = new DataTable();
        //    model.flag = "get";
        //    DataSet ds = _user.GetDomain(model);
        //    if (ds.Tables.Count > 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            list.Add(new DomainModel
        //            {
        //                id = Convert.ToInt32(dr["DomainID"]),
        //                domainName = dr["DomainName"].ToString()
        //            });
        //        }
        //    }
        //    return list;
        //}
        public List<DepartmentModel> FetchDepartment(string domainName)
        {
            List<DepartmentModel> deptList = new List<DepartmentModel>();
            if (!string.IsNullOrEmpty(domainName))
            {
				deptList = _departmentWorker.GetDepartments().Where(d=>d.DomainName == domainName).ToList();                

            }
            return deptList;
        }
        //public List<UserGridModel> UserList(string Name, string EmpId, string Email, string UserType, string Domain, string Department)
        //{
        //    List<UserGridModel> list = new List<UserGridModel>();
        //    UserGridModel model = new UserGridModel();
        //    DataTable dt = new DataTable();

        //    model.Name = Name;
        //    model.EmpID = EmpId;
        //    model.Email = Email;
        //    model.UserType = UserType;
        //    model.Domain = Domain;
        //    model.Department = Department;

        //    DataSet ds = _user.GetUser(model);
        //    if (ds.Tables.Count > 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            list.Add(new UserGridModel
        //            {
        //                EmpID = dr["EmpID"].ToString(),
        //                Name = dr["Name"].ToString(),
        //                Email = dr["Email"].ToString(),
        //                Gender = dr["Gender"].ToString(),
        //                Domain = dr["Domain"].ToString(),
        //                Department = dr["Department"].ToString(),
        //                UserType = dr["UserType"].ToString(),
        //                ImageApprover = Convert.ToInt16(dr["ImageApprover"]),
        //                Status = Convert.ToInt16(dr["Status"])
        //            });
        //        }
        //    }
        //    return list;
        //}

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
