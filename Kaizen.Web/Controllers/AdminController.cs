using Kaizen.Data.Constant;
using Kaizen.Business.Interface;
using Kaizen.Models.AdminModel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection;
using Kaizen.Models.ViewUserModel;
using Kaizen.Data.DataServices;

namespace Kaizen.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBlock _worker;
        private readonly IDomain _domainWorker;

        private readonly IWebHostEnvironment _environment;

        public AdminController(IBlock worker, IDomain domainWorker)
        {
            _worker = worker;
            _domainWorker = domainWorker;

        }
        public IActionResult Index()
        {
            return View();
        }
		public IActionResult AddUser()
		{
			AddUserData db = new AddUserData();
			AddUserModel model = new AddUserModel();
			model.cadre = db.GetCadreList();
			model.UserType = db.GetUserTypeList();
			model.Domain = db.GetDomainTypeList();

			return View(model);
		}

		[HttpPost]
		public IActionResult Adduser(AddUserModel ur)
		{
			try
			{
				string msg;
				AddUserData db = new AddUserData();
				ur.cadre = db.GetCadreList();
				ur.UserType = db.GetUserTypeList();
				ur.Domain = db.GetDomainTypeList();
				if (ModelState.IsValid)
				{
					msg = db.InsertUserData(ur);
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
            return View();
        }
        public IActionResult AddBlock()
        {
            List<BlockModel> newList = new List<BlockModel>();
            try
            {
                DataTable dt = new DataTable();
                newList = Blocklist();
            }
            catch (Exception ex) { LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment); }

            return View(newList);
        }
        [HttpPost]
        public IActionResult AddBlock(string blockName)
        {
            List<BlockModel> newList = new List<BlockModel>();
            BlockModel model = new BlockModel();
            model.blockName= blockName;
            model.flag = "insert";
            string outmsg = "";
            DataTable dt = new DataTable();
            try
            {
                if (!string.IsNullOrEmpty(model.blockName))
                {
                    outmsg = _worker.CreateBlock(model);
                    newList = Blocklist();
                }
            }
            catch (Exception ex) { LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment); }
            return Ok(newList);
        }
        public IActionResult DeleteBlock(int id)
        {
            List<BlockModel> newList = new List<BlockModel>();
            BlockModel model = new BlockModel();
            DataTable dt = new DataTable();
            string outmsg = "";
            model.flag = "delete";
            model.id = id;
                outmsg = _worker.DeleteBlock(model);
                newList = Blocklist();


            return RedirectToAction("AddBlock");
        }
        public IActionResult ActiveBlock(int id)
        {
            List<BlockModel> newList = new List<BlockModel>();
            BlockModel model = new BlockModel();
            DataTable dt = new DataTable();
            string outmsg = "";
            model.flag = "Active";
            model.id = id;
            outmsg = _worker.DeleteBlock(model);
            newList = Blocklist();


            return RedirectToAction("AddBlock");
        }
        public IActionResult InActiveBlock(int id)
        {
            List<BlockModel> newList = new List<BlockModel>();
            BlockModel model = new BlockModel();
            DataTable dt = new DataTable();
            string outmsg = "";
            model.flag = "InActive";
            model.id = id;
            outmsg = _worker.DeleteBlock(model);
            newList = Blocklist();


            return RedirectToAction("AddBlock");
        }
        public List<BlockModel> Blocklist()
        {

            List<BlockModel> list = new List<BlockModel>();
            BlockModel model = new BlockModel();
            model.flag = "get";
            try
            {
                DataSet ds = _worker.GetBlock(model);
                if (ds.Tables.Count >=0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new BlockModel
                        {
                            id = Convert.ToInt32(dr["BlockId"]),
                            blockName = dr["BlockDescrption"].ToString(),
                            statusID = Convert.ToInt32(dr["Status"])
                        });
                    }
                }
            }
            catch (Exception ex) { LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment); }

            return list;
        }

        //Domain
        public IActionResult AddDomain()
        {
            List<DomainModel> newList = new List<DomainModel>();
            try
            {
                DataTable dt = new DataTable();
                newList = Domainlist();
            }
            catch (Exception ex) { }

            return View(newList);
        }

        [HttpPost]
        public IActionResult AddDomain(string DomainName)
        {

            List<DomainModel> list = new List<DomainModel>();
            DomainModel model = new DomainModel();
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(DomainName))
            {
                string flag = "insert";
                string outmsg = _domainWorker.CreateDomain(DomainName);
                if (outmsg == "Domain Created Successfully !!")
                {
                    TempData["msg"] = outmsg;
                }
            }
            List<DomainModel> newList = Domainlist();
            return Ok(newList);

        }

        public List<DomainModel> Domainlist()
        {
            List<DomainModel> list = new List<DomainModel>();
            DomainModel model = new DomainModel();
            DataTable dt = new DataTable();
            model.flag = "get";
            DataSet ds = _domainWorker.GetDomain(model);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new DomainModel
                    {
                        id = Convert.ToInt32(dr["DomainID"]),
                        DomainName = dr["DomainDesc"].ToString(),
                        StatusID = Convert.ToBoolean(dr["Status"])
                    });
                }
            }
            return list;
        }

        public IActionResult DeleteDomain(int id)
        {
            DomainModel model = new DomainModel();
            model.flag = "delete";
            DataTable dt = new DataTable();
            if (id > 0)
            {
                string outmsg = _domainWorker.DeleteDomain(model, id);
                if (outmsg == "Domain deleted successfully!")
                {
                    TempData["msg"] = outmsg;
                }
            }
            List<DomainModel> newList = Domainlist();
            return View("AddDomain", newList);
        }

        public IActionResult ActiveDomain(int id)
        {
            DomainModel model = new DomainModel();
            model.flag = "Status";
            DataTable dt = new DataTable();
            if (id > 0)
            {
                string outmsg = _domainWorker.InActiveDomain(model, id);
                //TempData["msg"] = "Status  Updated successfully!";

            }
            List<DomainModel> newList = Domainlist();
            return View("AddDomain", newList);

        }

        public IActionResult IActiveDomain(int id)
        {
            DomainModel model = new DomainModel();
            model.flag = "Status";
            DataTable dt = new DataTable();
            if (id > 0)
            {
                string outmsg = _domainWorker.ActiveDomain(model, id);
                //TempData["msg"] = "Status  Updated successfully!";

            }
            List<DomainModel> newList = Domainlist();
            return View("AddDomain", newList);

        }


		//EndDomain

		public List<DepartmentModel> FetchDepartment(string DomainName)
		{
			List<DepartmentModel> list = new List<DepartmentModel>();
			AddUserData db = new AddUserData();
			DepartmentModel model = new DepartmentModel();
			DataTable dt = new DataTable();
			if (!string.IsNullOrEmpty(DomainName))
			{
				DataSet ds = db.GetDepartment(DomainName);
				if (ds.Tables.Count > 0)
				{
					foreach (DataRow dr in ds.Tables[0].Rows)
					{
						list.Add(new DepartmentModel
						{
							DeptId = Convert.ToInt32(dr["DeptId"].ToString()),
							DepartmentName = dr["DepartmentName"].ToString()
						});
					}
				}

			}

			return list;
		}

	}
}
