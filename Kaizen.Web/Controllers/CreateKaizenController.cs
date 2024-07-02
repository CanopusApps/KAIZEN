using Kaizen.Business.Interface;
using Kaizen.Business.Worker;
using Kaizen.Data.Constant;
using Kaizen.Models.AdminModel;
using Kaizen.Models.NewKaizen;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Kaizen.Web.Controllers
{
    public class CreateKaizenController : Controller
    {
		public IHttpContextAccessor conAccessor;
		private readonly IBlock _blockWorker;
		private readonly ICreateNewKaizen _createNewKaizen;
        NewKaizenModel model = new NewKaizenModel();
		public CreateKaizenController(IBlock worker,ICreateNewKaizen kaizenWorker, IHttpContextAccessor conAccessor)
		{
			_blockWorker = worker;
			_createNewKaizen = kaizenWorker;
		}
		public IActionResult NewKaizen()
		{
			try
			{
				model.EmpId = "614678";
				model.BlockList = _blockWorker.GetBlock();
				model = _createNewKaizen.GetKaizenOriginatedby(model);
			}
			catch (Exception ex) { LogEvents.LogToFile(DbFiles.Title, ex.ToString()); }
            return View(model);
        }
		[HttpPost]
		public IActionResult NewKaizen(NewKaizenModel model)
		{

			return View();
		}

		[HttpPost]
		public IActionResult GetTeamMemberDetails(NewKaizenModel model)
		{

            model = _createNewKaizen.GetKaizenOriginatedby(model);

            return Ok(model); 
		}
    }
}
