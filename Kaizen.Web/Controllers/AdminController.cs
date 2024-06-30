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
                ModelState.Remove(nameof(userModel.CreatedbyId));
              
                //userModel.CreatedbyId = conAccessor.HttpContext.Session.GetString("EmpId");
                //userModel.CreatedbyId = Username;
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
        public IActionResult AddBlock(BlockModel blockmodel)
        {
            bool insertStatus = false;
            try
            {
                blockmodel.CreatedBy = conAccessor.HttpContext.Session.GetString("EmpId");
                if (ModelState.IsValid)
                {
                    insertStatus = _blockWorker.InsertBlockDetails(blockmodel);
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


        [HttpPost]
        public IActionResult UpdateBlock(BlockModel blockmodel)
        {
            bool updateStatus = false;
            try
            {
                blockmodel. ModifiedBy = conAccessor.HttpContext.Session.GetString("EmpId");
                if (ModelState.IsValid)
                {
                    updateStatus = _blockWorker.UpdateBlockDetails( blockmodel);
                    if (updateStatus)
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


        [HttpPost]
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
            return Ok(blocks);
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
                if (ModelState.IsValid)
                {
                    insertStatus = _domainWorker.CreateDomain(domainmodel);
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
        [HttpPost]
        public IActionResult UpdateDomain(DomainModel domainmodel)
        {
            bool updateStatus = false;
            try
            {
                domainmodel. ModifiedBy =conAccessor.HttpContext.Session.GetString("EmpId");
                if (ModelState.IsValid)
                {
                    updateStatus = _domainWorker.UpdateDomainDetails(domainmodel);
                    if (updateStatus)
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
        [HttpPost]
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

            return Ok(domains);
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

        [HttpPost]
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
            return Ok(departments);
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
            editmodel.Cadre = _addUserWorker.GetCadre();
            editmodel.UserType = _addUserWorker.GetUserType();
            //editmodel.Departments = FetchDepartment("1002");
			//editmodel.Departments = _departmentWorker.GetDepartments();
			return View(editmodel);
        }
		[HttpPost]
		public IActionResult EditUser(EditUserModel editUserModel)
		{
			string msg="";
			ModelState.Remove(nameof(editUserModel.UserType));
			ModelState.Remove(nameof(editUserModel.Cadre));
			ModelState.Remove(nameof(editUserModel.Domains));
			ModelState.Remove(nameof(editUserModel.Departments));
			if (ModelState.IsValid)
			{
                msg = _editUserWorker.EditUser(editUserModel);
                if (msg == "ok")
				{
					TempData["msg"] = "Data saved Sucessfully ";
				}
				else if (msg == "Employee doesnot exist.")
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

			return RedirectToAction("ViewUser", "ViewUser");
		}

        public IActionResult TeamTable()
        {
            return View();
        }

    }
}
