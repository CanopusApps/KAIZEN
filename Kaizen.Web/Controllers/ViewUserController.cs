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

namespace Kaizen.Web.Controllers
{
    public class ViewUserController : Controller
    {
        private readonly IViewuser _user;
        private readonly IWebHostEnvironment _environment;

        public ViewUserController(IViewuser worker)
        {
            _user = worker;
        }

        //Created by Manas 
        public IActionResult ViewUser(string? Name, string? EmpId, string? Email, string? UserType, string? Domain, string? Department)
        {
            ViewUserallModel viewModel = new ViewUserallModel();
            try
            {
                    viewModel.UserTypeList = UserTypeList();
                    viewModel.DomainList = DomainList();
                    viewModel.UsergridList = UserList(Name, EmpId, Email, UserType, Domain, Department); 
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
                var userList = UserList(Name, EmpId, Email, UserType, Domain, Department);
                return Json(userList);
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                // LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment); 
                return Json(new { success = false, message = ex.Message });
            }
        }
        public List<UserTypeModel> UserTypeList()
        {
            List<UserTypeModel> list = new List<UserTypeModel>();
            UserTypeModel model = new UserTypeModel();
            DataTable dt = new DataTable();
            model.flag = "get";
            DataSet ds = _user.GetUserType(model);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new UserTypeModel
                    {
                        UserTypeId = Convert.ToInt16(dr["UserTypeId"]),
                        UserDesc = dr["UserDesc"].ToString()
                    });
                }
            }
            return list;
        }
        public List<DomainModel> DomainList()
        {
            List<DomainModel> list = new List<DomainModel>();
            DomainModel model = new DomainModel();
            DataTable dt = new DataTable();
            model.flag = "get";
            DataSet ds = _user.GetDomain(model);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new DomainModel
                    {
                        id = Convert.ToInt32(dr["DomainID"]),
                        DomainName = dr["DomainDesc"].ToString()
                    });
                }
            }
            return list;
        }
        public List<DepartmentModel> FetchDepartment(string DomainName)
        {
            List<DepartmentModel> list = new List<DepartmentModel>();
            DepartmentModel model = new DepartmentModel();
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(DomainName))
            {
                DataSet ds = _user.GetDepartment(DomainName);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new DepartmentModel
                        {
                            DeptId = Convert.ToInt16(dr["DeptId"]),
                            DepartmentName = dr["DepartmentName"].ToString()
                        });
                    }
                }
                
            }
            return list;
        }
        public List<UserGridModel> UserList(string Name, string EmpId, string Email, string UserType, string Domain, string Department)
        {
            List<UserGridModel> list = new List<UserGridModel>();
            UserGridModel model = new UserGridModel();
            DataTable dt = new DataTable();

            model.Name = Name;
            model.EmpID = EmpId;
            model.Email = Email;
            model.UserType = UserType;
            model.Domain = Domain;
            model.Department = Department;

            DataSet ds = _user.GetUser(model);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new UserGridModel
                    {
                        EmpID = dr["EmpID"].ToString(),
                        Name = dr["Name"].ToString(),
                        Email = dr["Email"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        Domain = dr["Domain"].ToString(),
                        Department = dr["Department"].ToString(),
                        UserType = dr["UserType"].ToString(),
                        ImageApprover = Convert.ToInt16(dr["ImageApprover"]),
                        Status = Convert.ToInt16(dr["Status"])
                    });
                }
            }
            return list;
        }
    }
}
