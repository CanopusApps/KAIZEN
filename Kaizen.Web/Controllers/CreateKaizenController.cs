using Kaizen.Business.Interface;
using Kaizen.Business.Worker;
using Kaizen.Data.Constant;
using Kaizen.Models.AdminModel;
using Kaizen.Models.NewKaizen;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kaizen.Web.Controllers
{
    public class CreateKaizenController : Controller
    {
		public IHttpContextAccessor conAccessor;
		private readonly IBlock _blockWorker;
		private readonly ICreateNewKaizen _createNewKaizen;
        private readonly NewKaizenModel _infoSettings;

        NewKaizenModel model = new NewKaizenModel();
		public CreateKaizenController(IBlock worker,ICreateNewKaizen kaizenWorker, IHttpContextAccessor conAccessor, IOptions<NewKaizenModel> infoSettings)
		{
			_blockWorker = worker;
			_createNewKaizen = kaizenWorker;
            this.conAccessor = conAccessor;
            _infoSettings = infoSettings.Value;
        }
        public IActionResult NewKaizen()
		{
			try
			{
                //Guid id = Guid.NewGuid();// Sir Added Guid here for  Id
                //model.Id = id.ToString();
                // model.IEEmail = _infoSettings.IEEmail;
                //model.AccountEmail= _infoSettings.AccountEmail;
                model.IEEmail= conAccessor.HttpContext.Session.GetString("IEemail");
                model.AccountEmail = conAccessor.HttpContext.Session.GetString("FinanceEmail");
                model.name = conAccessor.HttpContext.Session.GetString("Message");
                model.EmpId = conAccessor.HttpContext.Session.GetString("EmpId");
                model.Domain = conAccessor.HttpContext.Session.GetString("Domain");
                model.Department = conAccessor.HttpContext.Session.GetString("Department");
                model.BlockList = _blockWorker.GetBlock();
                //model = _createNewKaizen.GetKaizenOriginatedby(model);
                DateTime currentDate  = DateTime.Today;
                model.OriginatedDate = currentDate.ToString("yyyy-MM-dd");
            }
			catch (Exception ex) { LogEvents.LogToFile(DbFiles.Title, ex.ToString()); }
            return View(model);
        }
		[HttpPost]
		public IActionResult NewKaizen(NewKaizenModel model)
		{
            
            model.insertStatus = false;
            Guid id = Guid.NewGuid();
            model.Id = id.ToString();
            string loginuserid= conAccessor.HttpContext.Session.GetString("UserID");
            if (model.MemberList != null)
            {
                model.MemberList.ForEach(m => m.KaizenId = id.ToString());
                model.MemberList.ForEach(m => m.CreatedBy = loginuserid.ToString());
            }
            if (model.DeploymentList!=null)
            { 
            model.DeploymentList.ForEach(m => m.KaizenId = id.ToString());
                model.DeploymentList.ForEach(m => m.CreatedBy = loginuserid.ToString());
            }
            model.CreatedBy = conAccessor.HttpContext.Session.GetString("EmpId");

            model.insertStatus = _createNewKaizen.CreateNewKaizen(model);
            return Ok(model.insertStatus);
		}

		[HttpPost]
		public IActionResult GetTeamMemberDetails(NewKaizenModel model)
		{
            model = _createNewKaizen.GetKaizenOriginatedby(model);
            return Ok(model); 
		}
        public List<TeamMemberDetails> GetTeamMember(TeamMemberDetails model)
        {
            List<TeamMemberDetails> teamlist = new List<TeamMemberDetails>();
            teamlist = _createNewKaizen.getTeamdetails(model);
            return teamlist;
        }

    }
}
