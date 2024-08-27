using Kaizen.Business.Worker;
using Kaizen.Data.Constant;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.AspNetCore.Session;
using Kaizen.Business.Interface;
using Kaizen.Models.AdminModel;
using System.Data;

namespace Kaizen.Web.Controllers
{
    public class ProfileController : Controller
    {
        public IHttpContextAccessor _conAccessor;
        private readonly IProfile _profileWorker;
        private readonly IWebHostEnvironment? _environment;

        ProfileModel model = new ProfileModel();

        public ProfileController(IHttpContextAccessor conAccessor, IProfile profileWorker)
        {
            this._conAccessor = conAccessor;
            _profileWorker = profileWorker;
        }

        public IActionResult Profile()
        {
            try
            {
                string empid = _conAccessor.HttpContext.Session.GetString("EmpId");
                model = _profileWorker.UserProfile(empid);
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Profile(ProfileModel model)
        {
            bool updateStatus = false;
            try
            {
                updateStatus = _profileWorker.UpdateUserProfile(model);
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return Ok(updateStatus);
        }
    }
}
