using Microsoft.AspNetCore.Mvc;

namespace Kaizen.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
