using Kaizen.Business.Interface;
using Kaizen.Web.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Kaizen.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBlock _worker;

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
            return View();
        }

        [HttpPost]
        public IActionResult AddBlock(string blockName)
        {
            DataTable dt = new DataTable();
            string flag = "insert";
            if (!string.IsNullOrEmpty(blockName))
            {
                string outmsg = _worker.CreateBlock(blockName, out string msg);
            }



            return View();
        }

    }
}
