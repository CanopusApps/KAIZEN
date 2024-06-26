using Microsoft.AspNetCore.Mvc;

namespace Kaizen.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboardtab1()
        {
            return View();
        }
        public IActionResult Dashboardtab2()
        {
            return View();
        }
        public IActionResult Dashboardtab3()
        {
            return View();
        }
    }
}
