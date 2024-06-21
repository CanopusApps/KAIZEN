using Kaizen.Data.Constant;
using Kaizen.Business.Interface;
using Kaizen.Models;
using Kaizen.Models.AdminModel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection;

namespace Kaizen.Web.Controllers
{
    public class AdminController : Controller
    {
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

        public AdminController(IBlock worker, IDomain domainWorker, IDepartment departmentWorker, IAddUser addUserWorker,IEditUser editUserWorker)
        {
            _blockWorker = worker;
            _domainWorker = domainWorker;
            _departmentWorker = departmentWorker;
            _addUserWorker = addUserWorker;
            _editUserWorker = editUserWorker;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddUser()
        
        {
            AddUserModel model = new AddUserModel();
            model.Cadre = _addUserWorker.GetCadre();
            model.UserType = _addUserWorker.GetUserType();
            model.Domains = _domainWorker.GetDomain();
            //model.Departments = _departmentWorker.GetDepartments();


            return View(model);
        }

        [HttpPost]
        public IActionResult Adduser(AddUserModel userModel)
        {
            try
            { 
                string msg;
                ModelState.Remove(nameof(userModel.UserType));
                ModelState.Remove(nameof(userModel.Cadre));
                ModelState.Remove(nameof(userModel.Domains));
                ModelState.Remove(nameof(userModel.Departments));
                if (ModelState.IsValid)
                {
                    msg = _addUserWorker.AddUser(userModel);
                    if (msg == "ok")
                   {
                       TempData["msg"] = "Data saved Sucessfully ";
                   }
                   else if (msg == "Duplicate Emp Id")
                   {
                       TempData["msg"] = msg;
                   }
                    else
                   {
                        TempData["msg"] = "some error occured";
                  }

                }
                else
                {

                   TempData["msg"] = "some data Feids missing";
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
        public IActionResult AddBlock(string blockName)
        {
            bool insertStatus = false;
            try
            {
                if (!string.IsNullOrEmpty(blockName))
                {
                    insertStatus = _blockWorker.InsertBlockDetails(blockName);
                    if (insertStatus)
                    {
                        blocks = _blockWorker.GetBlock();
                    }
                }
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return Ok(blocks);
        }
        public IActionResult DeleteBlock(int id)
        {
            
            bool deleteStatus = false;

           try

            {
                deleteStatus = _blockWorker.DeleteBlock(id);
                if (deleteStatus)
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
        public IActionResult AddDomain(string domainName)
        {
            bool insertStatus = false;
            try
            {
                if (!string.IsNullOrEmpty(domainName))
                {
                    insertStatus = _domainWorker.CreateDomain(domainName);
                    if (insertStatus)
                    {
                        domains = _domainWorker.GetDomain();
                    }
                }
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return Ok(domains);
        }
        
        public IActionResult DeleteDomain(int id)
        {
            bool deleteStatus = false;
            try
            {
                deleteStatus = _domainWorker.DeleteDomain(id);
                if (deleteStatus)
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
        public IActionResult AddDepartment(int domainId, string DomainName, string DepartmentName)
        {
            bool insertStatus = false;
            List<DepartmentModel> departments = new List<DepartmentModel>();
            try
            {
                if (domainId > 0 && !string.IsNullOrEmpty(DomainName) && !string.IsNullOrEmpty(DepartmentName))
                {
                    insertStatus = _departmentWorker.CreateDepartment(domainId, DomainName, DepartmentName);
                    if(insertStatus)
                    {
                        departments = _departmentWorker.GetDepartments();
                    }
                }
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return Ok(departments);
        }		
        public List<DepartmentModel> FetchDepartment(string domainId)
        {
            departments = _departmentWorker.GetDepartments();
            return departments.Where(m => m.DomainId == Convert.ToInt32(domainId)).ToList();
        }

        public List<DomainModel> DomainList()
        {
            list = _departmentWorker.GetDomain(model);
            return list;
        }
        public IActionResult DeleteDepartment(int id)
        {
            bool deleteStatus = false;
            try
            {
                deleteStatus = _departmentWorker.DeleteDepartment(id);
                if (deleteStatus)
                {
                    departments = _departmentWorker.GetDepartments();
                }
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return RedirectToAction("AddDepartment");
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
            editmodel.Domains = _domainWorker.GetDomain();
            editmodel.Departments = _departmentWorker.GetDepartments();
            editmodel.Cadre = _editUserWorker.GetCadre();
            editmodel.StatusName = _editUserWorker.GetStatus();
            //editmodel.UserType = _editUserWo
            return View(editmodel);
        }

    }
}
