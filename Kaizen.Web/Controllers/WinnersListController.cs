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

namespace Kaizen.Web.Controllers
{
    public class WinnersListController : Controller
    {
        public IHttpContextAccessor conAccessor;
        private readonly IWinnersList _addWinnerWorker;
        private readonly ICreateNewKaizen _createNewKaizen;
        public WinnersListController(IWinnersList _addWinnerWorker, ICreateNewKaizen _createNewKaizen, IHttpContextAccessor conAccessor)
        {
            this.conAccessor = conAccessor;
            this._addWinnerWorker = _addWinnerWorker;
            this._createNewKaizen = _createNewKaizen;
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
            ViewBag.WinnersList = winners;
            return View(winners);
        }

        [HttpPost]
        public IActionResult UpdateWinnersList([FromBody] WinnersListModel model)
        {
           model.ModifiedBy =conAccessor.HttpContext.Session.GetString("EmpId");
            var status= _addWinnerWorker.UpdateWinner(model);
            return Ok(status);
        }
        [HttpPost]
        public IActionResult WinnersList([FromBody] WinnersViewModel model)
        {
            
            if (model.WinnersList.Category != null)
            {

                model.WinnersList.CreatedBy = conAccessor.HttpContext.Session.GetString("EmpId");
                var result = _addWinnerWorker.AddWinner(model.WinnersList);

                return Ok("Posted");
            }
            else if (model.NewKaizen.EmpId != null)
            {
                model.NewKaizen = _createNewKaizen.GetKaizenOriginatedby(model.NewKaizen);
                return Ok(model.NewKaizen);
            }
            return BadRequest();
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
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

    }
}


