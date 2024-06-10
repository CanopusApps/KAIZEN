using Kaizen.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Kaizen.Business.Interface;

namespace Kaizen.Web.Controllers
{
    public class Account : Controller
    {
        private readonly  IAccount _worker;
        private readonly IConfiguration _configuration;

        public Account(IAccount worker)
        {
            _worker=worker;
        }
        public IActionResult Login()
        {
            return View();
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Login(Login user)
        {
           RegisterLog registerLog = new RegisterLog();
           DataTable dt = new DataTable();
            dt = _worker.LoginCheck(user);
            return View();
        }

    }
}
