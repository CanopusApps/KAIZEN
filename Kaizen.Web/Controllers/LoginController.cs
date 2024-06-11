using Microsoft.AspNetCore.Mvc;

namespace Kaizen.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
