using Kaizen.Data.Constant;
using Kaizen.Business.Interface;
using Kaizen.Models;
using Kaizen.Models.AdminModel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;

namespace Kaizen.Web.Controllers
{
    public class AdminController : Controller
    {
        public IHttpContextAccessor conAccessor;
        private readonly IBlock _blockWorker;
        private readonly IDomain _domainWorker;
		private readonly IDepartment _departmentWorker;
		private readonly IAddUser _addUserWorker;
		List<BlockModel> blocks;
        List<DepartmentModel> departments;
        List<DomainModel> domains;
        List<DomainModel> list = new List<DomainModel>();
        DomainModel model = new DomainModel();

        EditUserModel editmodel = new EditUserModel();
        private readonly IEditUser _editUserWorker;

        public AdminController(IBlock worker, IDomain domainWorker, IDepartment departmentWorker, IAddUser addUserWorker,IEditUser editUserWorker, IHttpContextAccessor conAccessor)
        {
            _blockWorker = worker;
            _domainWorker = domainWorker;
            _departmentWorker = departmentWorker;
            _addUserWorker = addUserWorker;
            _editUserWorker = editUserWorker;
            this.conAccessor = conAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles ="Admin,EMPLOYEE")]
        public IActionResult AddUser()

        {
            AddUserModel model = new AddUserModel();
            try
            {
                var activeBlocks = _blockWorker.GetBlock().Where(d => d.Status == true).ToList();
                model.Cadre = _addUserWorker.GetCadre();
                model.UserType = _addUserWorker.GetUserType();
                model.Domains = _domainWorker.GetDomain().Where(d => d.Status == true).ToList();
                model.Blocks = activeBlocks;
                // model.Departments = _departmentWorker.GetDepartments();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());

            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Adduser(AddUserModel userModel)
            {
            try
            { 
                string msg;
                ModelState.Remove(nameof(userModel.Blocks));
                ModelState.Remove(nameof(userModel.UserType));
                ModelState.Remove(nameof(userModel.Cadre));
                ModelState.Remove(nameof(userModel.Domains));
                ModelState.Remove(nameof(userModel.Departments));
                ModelState.Remove(nameof(userModel.CreatedbyId));
               
                if (userModel.MiddleName==null)
                {
                    ModelState.Remove(nameof(userModel.MiddleName));
                }
               
                if (ModelState.IsValid)
                {
                    userModel.CreatedbyId = conAccessor.HttpContext.Session.GetString("EmpId");
                    msg = _addUserWorker.AddUser(userModel);
                   
                    if (msg == "ok")
                   {
                       TempData["addmsg"] = "Data saved Sucessfully ";
                   }
                   else if (msg == "Duplicate Emp Id")
                   {
                       TempData["addmsg"] = msg;
                   }
                    else
                   {
                        TempData["addmsg"] = "some error occured";
                  }

                }
                else
                {

                   TempData["addmsg"] = "some data Feids missing";
                }
                return RedirectToAction("Adduser");
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }
        public IActionResult AddBlock()
        {
            try
            {
                blocks = _blockWorker.GetBlock();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }

            return View(blocks);
        }
        [HttpPost]
        public IActionResult AddBlock(BlockModel blockmodel)
        {
            bool insertStatus = false;
            try
            {
                blockmodel.CreatedBy = conAccessor.HttpContext.Session.GetString("EmpId");
                
                    insertStatus = _blockWorker.InsertBlockDetails(blockmodel);
                
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return Ok(insertStatus);
        }


        [HttpPost]
        public IActionResult UpdateBlock(BlockModel blockmodel)
        {
            bool updateStatus = false;
            try
            {
                blockmodel. ModifiedBy = conAccessor.HttpContext.Session.GetString("EmpId");
                updateStatus = _blockWorker.UpdateBlockDetails( blockmodel);                   
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return Ok(updateStatus);
        }


        [HttpPost]
        public IActionResult DeleteBlock(int id)
        {
            bool deleteStatus = false;
           try

            {
                deleteStatus = _blockWorker.DeleteBlock(id);
                //if (deleteStatus)
                //{
                //    blocks = _blockWorker.GetBlock();
                //}
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());

            }
            return Ok(deleteStatus);
        }
        public IActionResult UpdateBlockStatus(int id, bool status)
        {
            bool updateStatus = false;
            try
            {
                updateStatus = _blockWorker.UpdateBlockStatus(id, status);
                if (updateStatus)
                {
                    blocks = _blockWorker.GetBlock();
                }
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return RedirectToAction("AddBlock");
        }

        public IActionResult AddDomain()
        {
            try
            {
                domains = _domainWorker.GetDomain();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }

            return View(domains);
        }
        [HttpPost]
        public IActionResult AddDomain(DomainModel domainmodel)
        {
            bool insertStatus = false;
            try
            {
                domainmodel. CreatedBy = conAccessor.HttpContext.Session.GetString("EmpId");
                    insertStatus = _domainWorker.CreateDomain(domainmodel);       
                
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return Ok(insertStatus);
        }
        [HttpPost]
        public IActionResult UpdateDomain(DomainModel domainmodel)
        {
            bool updateStatus = false;
            try
            {
                domainmodel. ModifiedBy =conAccessor.HttpContext.Session.GetString("EmpId");
                updateStatus = _domainWorker.UpdateDomainDetails(domainmodel);
                //if (ModelState.IsValid)
                //{
                //updateStatus = _domainWorker.UpdateDomainDetails(domainmodel);
                //}
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return Ok(updateStatus);
        }
        [HttpPost]
        public IActionResult DeleteDomain(int id)
        {
            bool deleteStatus = false;
            try
            {
                deleteStatus = _domainWorker.DeleteDomain(id);
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }

            return Ok(deleteStatus);
        }

        public IActionResult UpdateDomainStatus(int id, bool status)
        {
            bool updateStatus = false;
            try
            {
                updateStatus = _domainWorker.UpdateDomainStatus(status,id);
                if (updateStatus)
                {
                    domains = _domainWorker.GetDomain();
                }
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return View("AddDomain", domains);

        }


        //public IActionResult IActiveDomain(int id)
        //{
        //    DomainModel model = new DomainModel();
        //    model.flag = "Status";
        //    DataTable dt = new DataTable();
        //    if (id > 0)
        //    {
        //        string outmsg = _domainWorker.ActiveDomain(model, id);
        //        //TempData["msg"] = "Status  Updated successfully!";

        //    }
        //    List<DomainModel> newList = Domainlist();
        //    return View("AddDomain", newList);

        //}

     //Departments start

        public IActionResult AddDepartment()
        {
            DepartmentModel departmentModel = new DepartmentModel();
            departmentModel.DomainList = DomainList();
            List<DepartmentModel> departments = new List<DepartmentModel>();
            try
            {
                departments = _departmentWorker.GetDepartments();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            ViewBag.DepartmentList = departments;
            return View(departmentModel);
        }

        [HttpPost]
        public IActionResult AddDepartment(DepartmentModel departmentModel)
        {
            bool insertStatus = false;
            List<DepartmentModel> departments = new List<DepartmentModel>();
            try
            {
                string msg;
                departmentModel.CreatedBy = conAccessor.HttpContext.Session.GetString("EmpId");
                
                
                    insertStatus = _departmentWorker.CreateDepartment( departmentModel);
                    //if(insertStatus)
                    //{
                    //    departments = _departmentWorker.GetDepartments();
                    //}
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return Ok(insertStatus);
        }
        public List<DepartmentModel> FetchDepartment(string domainId)
        {
            try
            {
                var departments = _departmentWorker.GetDepartments();
                return departments.Where(m => m.DomainId == Convert.ToInt32(domainId) && m.Status == true).ToList();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return new List<DepartmentModel>(); // Return an empty list in case of an exception
            }
        }

        public List<DomainModel> DomainList()
        {
            try
            {
                var activeDomains = _departmentWorker.GetDomain().Where(d => d.Status == true).ToList();
                list = activeDomains;
                return list;
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return new List<DomainModel>(); // Return an empty list in case of an exception
            }
        }

        [HttpPost]
        public IActionResult UpdateDepartment(DepartmentModel departmentmodel)
        {
            bool updateStatus = false;
            try
            {
                ModelState.Remove(nameof(departmentmodel.DepartmentList));
                ModelState.Remove(nameof(departmentmodel.DomainList ));
                departmentmodel.ModifiedBY = conAccessor.HttpContext.Session.GetString("EmpId");
                if (ModelState.IsValid)
                {
                    updateStatus = _departmentWorker.UpdateDepartmentDetails(departmentmodel);
                    //if (updateStatus)
                    //{
                    //    //domains = _domainWorker.GetDomain();
                    //    departments = _departmentWorker.GetDepartments();
                    //}
                }
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return Ok(updateStatus);
        }


        [HttpPost]
        public IActionResult DeleteDepartment(int id)
        {
            bool deleteStatus = false;
            try
            {
                deleteStatus = _departmentWorker.DeleteDepartment(id);
                
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return Ok(deleteStatus);
        }
        public IActionResult UpdateDepartmentStatus(int id, bool status)
        {
            bool updateStatus = false;
            List<DepartmentModel> departments = new List<DepartmentModel>();
            try
            {
                updateStatus = _departmentWorker.UpdateDepartmentStatus(status, id);
                if (updateStatus)
                {
                    departments = _departmentWorker.GetDepartments();
                }
            }
            catch (Exception ex)
            {
               LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            DepartmentModel departmentModel = new DepartmentModel
            {
                DomainList = DomainList()
            };
            ViewBag.DepartmentList = departments;
            return View("AddDepartment", departmentModel);
        }

        //End Department

        public IActionResult EditUser()
        {
            try
            {
                editmodel.Domains = _domainWorker.GetDomain().Where(d => d.Status == true).ToList();
                editmodel.Cadre = _addUserWorker.GetCadre();
                editmodel.UserType = _addUserWorker.GetUserType();
                editmodel.Blocks = _blockWorker.GetBlock();
                //editmodel.Departments = FetchDepartment("1002");
                //editmodel.Departments = _departmentWorker.GetDepartments();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
               
            }
            return View(editmodel);
        }
		[HttpPost]
		public IActionResult EditUser(EditUserModel editUserModel)
		{
			string msg="";
            try
            {
                editUserModel.ModifiedBy = conAccessor.HttpContext.Session.GetString("EmpId");
                ModelState.Remove(nameof(editUserModel.UserType));
                ModelState.Remove(nameof(editUserModel.Cadre));
                ModelState.Remove(nameof(editUserModel.Domains));
                ModelState.Remove(nameof(editUserModel.Departments));
                ModelState.Remove(nameof(editUserModel.ModifiedBy));
                ModelState.Remove(nameof(editUserModel.MiddleName));
                ModelState.Remove(nameof(editUserModel.Blocks));

                if (ModelState.IsValid)
                {
                    msg = _editUserWorker.EditUser(editUserModel);
                    if (msg == "ok")
                    {
                        TempData["Editmsg"] = "Data saved Sucessfully ";
                    }
                    else if (msg == "Employee doesnot exist.")
                    {
                        TempData["Editmsg"] = msg;
                    }
                    else
                    {
                        TempData["Editmsg"] = "some error occured";
                    }

                }
                else
                {

                    TempData["msg"] = "some data Feids missing";
                }

            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                TempData["Editmsg"] = "An error occurred while processing your request.";
            }

            return RedirectToAction("ViewUser", "ViewUser");
		}

        public IActionResult TeamTable()
        {
            return View();
        }

        public IActionResult CheckIfExists(string value)
        {
            bool exists  = _addUserWorker.Checkuser(value);
            return Json(new { exists = exists });
        }


    }
}
