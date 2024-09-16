using Kaizen.Data.Constant;
using Kaizen.Business.Interface;
using Kaizen.Models;
using Kaizen.Models.AdminModel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection;
using Kaizen.Models.NewKaizen;
using Kaizen.Business.Worker;
using Kaizen.Models.WinnersList;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace Kaizen.Web.Controllers
{
    [Authorize(Roles = "ADM")]
    public class WinnersListController : Controller
    {
        public IHttpContextAccessor conAccessor;
        private readonly IWinnersList _addWinnerWorker;
        private readonly ICreateNewKaizen _createNewKaizen;
        private readonly WinnersListModel _infoSettings;
        public WinnersListController(IWinnersList _addWinnerWorker, ICreateNewKaizen _createNewKaizen, IHttpContextAccessor conAccessor, IOptions<WinnersListModel> infoSettings)
        {
            this.conAccessor = conAccessor;
            this._addWinnerWorker = _addWinnerWorker;
            this._createNewKaizen = _createNewKaizen;
            _infoSettings = infoSettings.Value;
        }
        [HttpGet]
        public IActionResult WinnersList()
        {

            WinnersListModel WModel = new WinnersListModel();
            List<WinnersListModel> winners = new List<WinnersListModel>();
            try
            {
                winners = _addWinnerWorker.GetWinners();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());

            }
            var sortedWinners = winners.OrderBy(w => w.Category).ToList();
            return View(sortedWinners);
        }

        [HttpPost]
        public IActionResult UpdateWinnersList(WinnersViewModel model)
        {
            try
            {

                model.WinnersList.ModifiedBy = conAccessor.HttpContext.Session.GetString("EmpId");
                if (model.WinnersList.Winnerimage != null)
                {

                    model.WinnersList.winnerimagefilepath = SaveUploadedFile(model.WinnersList.Winnerimage);
                }
                var status = _addWinnerWorker.UpdateWinner(model.WinnersList);
                return Ok(status);
            }
            catch (Exception ex)
            {
                // Log the exception with a descriptive message
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());

                // Return an internal server error status with a descriptive message
                return StatusCode(500, "An error occurred while updating the winners list.");
            }
        }
        [HttpPost]
        public IActionResult WinnersList(WinnersViewModel model)
        {
            try
            {
                model.WinnersList.winnerimagefilepath = SaveUploadedFile(model.WinnersList.Winnerimage);
                model.WinnersList.CreatedBy = conAccessor.HttpContext.Session.GetString("EmpId");
                var result = _addWinnerWorker.AddWinner(model.WinnersList);
                return Ok(result);
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View(model);
            }

        }
        [HttpPost]
        public IActionResult GetUserdatabyemp([FromBody] WinnersViewModel model)
        {
            try
            {
                model.NewKaizen = _createNewKaizen.GetKaizenOriginatedby(model.NewKaizen);
                return Ok(model.NewKaizen);
            }
            catch(Exception ex)
            {

                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return StatusCode(500, "An error occurred while retrieving user data.");
            }
        }
            [HttpPost]
        public IActionResult DeleteWinner(int id, String sd, String ed)
        {
            bool deleteStatus = false;
            try

            {
                deleteStatus = _addWinnerWorker.DeleteWinner(id, sd, ed);
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return Ok(deleteStatus);
        }

        [HttpPost]
        public IActionResult UpdateWinnerStatus(WinnersListModel model)
        {
            try
            {
                String updateStatus = _addWinnerWorker.ToggleStatus(model);
                return Ok();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


        private string SaveUploadedFile(IFormFile file)
        {
            WinnersListModel model = new WinnersListModel();
            try
            {
                model.LogwinnerFilePath = _infoSettings.LogwinnerFilePath;

                if (!Directory.Exists(model.LogwinnerFilePath))
                {
                    Directory.CreateDirectory(model.LogwinnerFilePath);
                }

                string uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
                string filePath = Path.Combine(model.LogwinnerFilePath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return filePath;
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                throw;
            }
        }
        public IActionResult GetImage(string imagePath)
        {
            try
            {
                string serverPath = Path.Combine(_infoSettings.LogwinnerFilePath, imagePath);
                return PhysicalFile(serverPath, "image/jpeg");
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                // Return a 500 Internal Server Error status with a descriptive message
                return StatusCode(500, "An error occurred while retrieving the image.");
            }
        }

        public IActionResult ViewWinnersList()
        {
            WinnersListModel WModel = new WinnersListModel();
            List<WinnersListModel> winners = new List<WinnersListModel>();
            try
            {
                winners = _addWinnerWorker.GetWinners();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());

            }
            var sortedWinners = winners.OrderBy(w => w.Category).ToList();
            return View(sortedWinners);
        }

       

    }
}


