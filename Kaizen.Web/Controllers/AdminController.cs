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
        public IActionResult Adduser(AddUserModel ur)
        {
            try
            {
                string msg;
                ////AddUserRepository db = new AddUserRepository();
                //ur.cadre = db.GetCadreList();
                //ur.UserType = db.GetUserTypeList();
                //ur.Domain = db.GetDomainTypeList();
                //if (ModelState.IsValid)
                //{
                //    msg = db.InsertUserData(ur);
                //    if (msg == "ok")
                //    {
                //        TempData["msg"] = "Data saved Sucessfully ";
                //    }
                //    else if (msg == "Duplicate Emp Id")
                //    {
                //        TempData["msg"] = msg;
                //    }
                //    else
                //    {
                //        TempData["msg"] = "some error occured";
                //    }

                //}
                //else
                //{

                //    TempData["msg"] = "some data Feids missing";
                //}

                //return View(ur);
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
            //List<BlockModel> newList = new List<BlockModel>();
            bool deleteStatus = false;

            //BlockModel model = new BlockModel();
            ////DataTable dt = new DataTable();
            //model.flag = "delete";
            //model.id = id;
            deleteStatus = _blockWorker.DeleteBlock(id);
            if (deleteStatus)
            {
                blocks = _blockWorker.GetBlock();
            }

            return RedirectToAction("AddBlock");
        }
        //public IActionResult ActiveBlock(int id)
        //{
        //    List<BlockModel> newList = new List<BlockModel>();
        //    BlockModel model = new BlockModel();
        //    DataTable dt = new DataTable();
        //    string outmsg = "";
        //    model.flag = "Active";
        //    model.id = id;
        //    outmsg = _worker.DeleteBlock(model);
        //    newList = Blocklist();


        //    return RedirectToAction("AddBlock");
        //}
        public IActionResult UpdateBlockStatus(int id, bool status)
        {
            //List<BlockModel> newList = new List<BlockModel>();
            //BlockModel model = new BlockModel();
            ////DataTable dt = new DataTable();
            //string outmsg = "";
            //model.flag = "InActive";
            //model.status = status;

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
        //public List<BlockModel> Blocklist()
        //{

        //    List<BlockModel> list = new List<BlockModel>();
        //    BlockModel model = new BlockModel();
        //    model.flag = "get";
        //    try
        //    {
        //        DataSet ds = _worker.GetBlock(model);
        //        if (ds.Tables.Count >=0)
        //        {
        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                list.Add(new BlockModel
        //                {
        //                    id = Convert.ToInt32(dr["BlockId"]),
        //                    blockName = dr["BlockDescrption"].ToString(),
        //                    statusID = Convert.ToInt32(dr["Status"])
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex) { LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment); }

        //    return list;
        //}

        //Domain

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

        //[HttpPost]
        //public IActionResult AddDomain(string DomainName)
        //{

        //    List<DomainModel> list = new List<DomainModel>();
        //    DomainModel model = new DomainModel();
        //    DataTable dt = new DataTable();
        //    if (!string.IsNullOrEmpty(DomainName))
        //    {
        //        string flag = "insert";
        //        string outmsg = _domainWorker.CreateDomain(DomainName);
        //        if (outmsg == "Domain Created Successfully !!")
        //        {
        //            TempData["msg"] = outmsg;
        //        }
        //    }
        //    List<DomainModel> newList = Domainlist();
        //    return Ok(newList);

        //}

        //public List<DomainModel> Domainlist()
        //{

        //    domains = _domainWorker.GetDomain();
        //    if (ds.Tables.Count > 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            list.Add(new DomainModel
        //            {
        //                id = Convert.ToInt32(dr["DomainID"]),
        //                DomainName = dr["DomainDesc"].ToString(),
        //                StatusID = Convert.ToBoolean(dr["Status"])
        //            });
        //        }
        //    }
        //    return list;
        //}

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


		//EndDomain
		//Deaprtments
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
		public List<DepartmentModel> FetchDepartment(string domainName)
        {
			//List<DepartmentModel> list = new List<DepartmentModel>();
			//AddUserData db = new AddUserData();
			//DepartmentModel model = new DepartmentModel();
			//DataTable dt = new DataTable();
			//if (!string.IsNullOrEmpty(DomainName))
			//{
			//    DataSet ds = db.GetDepartment(DomainName);
			//    if (ds.Tables.Count > 0)
			//    {
			//        foreach (DataRow dr in ds.Tables[0].Rows)
			//        {
			//            list.Add(new DepartmentModel
			//            {
			//                DeptId = Convert.ToInt32(dr["DeptId"].ToString()),
			//                DepartmentName = dr["DepartmentName"].ToString()
			//            });
			//        }
			//    }

			//}
			departments = _departmentWorker.GetDepartments();
            return departments.Where(m=>m.DomainName == domainName).ToList();

        }

    }
}
