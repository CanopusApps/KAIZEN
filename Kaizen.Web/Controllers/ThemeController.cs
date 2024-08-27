using Kaizen.Data.Constant;
using Kaizen.Business.Interface;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.Theme;
using Kaizen.Data.DataServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection;
using Kaizen.Models.NewKaizen;
using Kaizen.Business.Worker;
using Kaizen.Models.WinnersList;
using Kaizen.Models.AdminModel;

namespace Kaizen.Web.Controllers
{

    public class ThemeController : Controller
    {

        public IHttpContextAccessor conAccessor;

        private readonly IThemeChanger _addThemeWorker;

        public ThemeController(IHttpContextAccessor conAccessor, IThemeChanger _addThemeWorker)
        {
            this.conAccessor = conAccessor;

            this._addThemeWorker = _addThemeWorker;
        }


        [HttpGet]
        public IActionResult ThemeChanger()
        {
            ThemeModel model = new ThemeModel();
            List<ThemeModel> RetrieveTheme = new List<ThemeModel>();
            try
            {
                RetrieveTheme = _addThemeWorker.RetrieveTheme();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
            ViewBag.ThemeList = RetrieveTheme;
            if (RetrieveTheme.Any())
            {
                ViewBag.SelectedTheme = RetrieveTheme.First().Theme;
            }

          
            return View(RetrieveTheme);
        }
        [HttpPost]
        public IActionResult ThemeChanger([FromBody] ThemeModel model)
        {
            bool status = false;
            try
            {
                model.ModifiedBy = conAccessor.HttpContext.Session.GetString("EmpId");
                status = _addThemeWorker.AddTheme(model);
                return Ok(status);
            }
            catch(Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }
        public IActionResult Kaizencriteria()
        {
            return View();
        }
        public IActionResult KaizenBreakthrough()
        {
            return View();
        }
    }
}
