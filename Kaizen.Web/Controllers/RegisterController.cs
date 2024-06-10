using Microsoft.AspNetCore.Mvc;

namespace Kaizen.Web.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
