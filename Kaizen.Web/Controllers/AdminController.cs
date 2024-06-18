using Kaizen.Data.Constant;
using Kaizen.Business.Interface;
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


        private readonly IWebHostEnvironment _environment;

        public AdminController(IBlock worker, IDomain domainWorker, IDepartment departmentWorker, IAddUser addUserWorker)
        {
            _blockWorker = worker;
            _domainWorker = domainWorker;
            _departmentWorker = departmentWorker;
            _addUserWorker = addUserWorker;

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
                LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment);
                return View();
            }
        }
        public IActionResult AddDepartment()
        {
			try
			{
				departments = _departmentWorker.GetDepartments();
			}
			catch (Exception ex)
			{
				LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment);
			}

			return View(departments);
		}
        public IActionResult AddBlock()
        {
            try
            {
                blocks = _blockWorker.GetBlock();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment);
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
                LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment);
            }
            return Ok(blocks);
        }
        public IActionResult DeleteBlock(int id)
        {
            
            bool deleteStatus = false;

           
            deleteStatus = _blockWorker.DeleteBlock(id);
            if (deleteStatus)
            {
                blocks = _blockWorker.GetBlock();
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
                LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment);
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
                LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment);
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
                LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment);
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
                LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment);
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
                LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment);
            }
            return View("AddDomain", domains);

        }
		public IActionResult DeleteDepartment(int id)
		{
			bool deleteStatus = false;
			deleteStatus = _departmentWorker.DeleteDepartment(id);
			if (deleteStatus)
			{
				departments = _departmentWorker.GetDepartments();
			}

			return RedirectToAction("AddDepartment");
		}

		public IActionResult UpdateDepartmentStatus(int id, bool status)
		{
			bool updateStatus = false;
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
				LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment);
			}
			return View("AddDomain", departments);

		}
		public List<DepartmentModel> FetchDepartment(string domainId)
        {
			departments = _departmentWorker.GetDepartments();
            return departments.Where(m=>m.DomainId== Convert.ToInt32(domainId)).ToList();

        }

    }
}
