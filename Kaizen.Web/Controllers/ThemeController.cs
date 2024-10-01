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
using Microsoft.AspNetCore.Authorization;

namespace Kaizen.Web.Controllers
{
    [Authorize(Roles = "ADM")]
    public class ThemeController : Controller
    {

        public IHttpContextAccessor conAccessor;

        private readonly IThemeChanger _addThemeWorker;
        List<ThemeModel> themes;

        public ThemeController(IHttpContextAccessor conAccessor, IThemeChanger _addThemeWorker)
        {
            this.conAccessor = conAccessor;

            this._addThemeWorker = _addThemeWorker;
          
        }

        // This method will retrieve themes when page loaded and if there is an active theme it retrieve that theme which is displayed in the sidebarlayout and login page
        [HttpGet]
        public IActionResult ThemeChanger()
        {
            List<ThemeModel> retrieveTheme = new List<ThemeModel>();

            try
            {
               
                retrieveTheme = _addThemeWorker.RetrieveTheme();
                var activeTheme = _addThemeWorker.GetActiveTheme(DateTime.Now);

                if (activeTheme != null)
                {
                    HttpContext.Session.SetString("SelectedTheme", activeTheme.Theme);
                    ViewBag.SelectedTheme = activeTheme.Theme;
                  
                }
                else
                {
                   
                    HttpContext.Session.Remove("SelectedTheme");
                }
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }

            // Pass the list of themes to the view
            return View(retrieveTheme);
        }

        // This method will add a new theme and return the status as JSON
        [HttpPost]
        public IActionResult ThemeChanger([FromBody] ThemeModel model)
        {
            bool status = false;
            try
            {
                model.CreatedBy = HttpContext.Session.GetString("EmpId");
                status = _addThemeWorker.AddTheme(model);

                // Return success status as JSON
                return Ok(status);
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return BadRequest("An error occurred while adding the theme.");
            }
        }

        // This method will Delete theme and return the status as JSON
        [HttpPost]
        public IActionResult DeleteTheme(int id,bool forceDelete = false)
        {

            bool deleteStatus = false;
            try
            {
                var activeTheme = _addThemeWorker.GetActiveTheme(DateTime.Now); 

                if (activeTheme != null && activeTheme.ThemeId == id && !forceDelete)
                {
                    
                    return Json(new { success = false,message = "You are about to delete an active theme.Are you sure you want to proceed ?"});
                    }

                // Proceed to delete the theme if it's not active
                deleteStatus = _addThemeWorker.DeleteTheme(id,forceDelete);
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return Json(false);
            }

            return Json(deleteStatus);
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
