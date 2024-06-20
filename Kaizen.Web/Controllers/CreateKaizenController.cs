using Microsoft.AspNetCore.Mvc;

namespace Kaizen.Web.Controllers
{
    public class CreateKaizenController : Controller
    {
        public IActionResult NewKaizen()
        {
            return View();
        }
    }
}
