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
using System.Data.OleDb;

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

        [HttpPost]
        public string Upload(IFormFile file, string Status, string UserType, string Password)
        {
            if (file == null || file.Length == 0)
            {
                return "No file uploaded.";
            }

            var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            Directory.CreateDirectory(uploadsPath); // Ensure the directory exists
            var filePath = Path.Combine(uploadsPath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            try
            {
                DataTable dataTable = ReadExcelIntoDataTable(filePath);

                foreach (DataRow row in dataTable.Rows)
                {
                    var employee = new UploadUserModel
                    {
                        EmpID = row["Emp Id"].ToString(),
                        FirstName = row["First Name"].ToString(),
                        MiddleName = row["Middle Name"].ToString(),
                        LastName = row["Last Name"].ToString(),
                        Gender = row["Gender"].ToString(),
                        Email = row["Email Id"].ToString(),
                        Domain = row["Domain"].ToString(),
                        Department = row["Department"].ToString(),
                        Cadre = row["Cadre"].ToString(),
                        PhoneNumber = row["Mobile No"].ToString(),
                        Status= Status,
                        UserType= UserType,
                        Password= Password
                    };
                    _viewUserWorker.SaveUploadedFile(employee);
                }
                return "File uploaded and data processed successfully.";
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return $"Internal server error";
            }
        }
        private DataTable ReadExcelIntoDataTable(string filePath)
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM [Sheet1$]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }
}
