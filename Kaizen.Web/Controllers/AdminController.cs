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
        private readonly IBlock _worker;
        private readonly IWebHostEnvironment _environment;

        public AdminController(IBlock worker)
        {
            _worker = worker;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }
        public IActionResult AddDomain()
        {
            return View();
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
                            id = Convert.ToInt32(dr["SrNo"]),
                            blockName = dr["BlockDescrption"].ToString(),
                            statusID = Convert.ToInt32(dr["Status"])
                        });
                    }
                }
            }
            catch (Exception ex) { LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment); }

            return list;
        }



    }
}
