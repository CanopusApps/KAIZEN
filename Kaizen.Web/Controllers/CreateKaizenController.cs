using Kaizen.Business.Interface;
using Kaizen.Business.Worker;
using Kaizen.Data.Constant;
using Microsoft.AspNetCore.Http;
using Kaizen.Models.AdminModel;
using Kaizen.Models.NewKaizen;
using Kaizen.Models.SubmmitedKaizen;
using Kaizen.Models.ViewUserModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using static NuGet.Client.ManagedCodeConventions;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Data;
using System.Net.Mail;

namespace Kaizen.Web.Controllers
{
    public class CreateKaizenController : Controller
    {
        public IHttpContextAccessor conAccessor;
        private readonly IBlock _blockWorker;
        private readonly IViewuser _viewuserWorker;
        private readonly ICreateNewKaizen _createNewKaizen;
        //private readonly string _uploadspath;
        private readonly NewKaizenModel _infoSettings; 

        NewKaizenModel model = new NewKaizenModel();

        public CreateKaizenController(IBlock worker, IViewuser viewuserworker  , ICreateNewKaizen kaizenWorker, IHttpContextAccessor conAccessor, IOptions<NewKaizenModel> infoSettings)
        {
            _blockWorker = worker;
            _viewuserWorker = viewuserworker;
            _createNewKaizen = kaizenWorker;
            this.conAccessor = conAccessor;
            _infoSettings = infoSettings.Value;
        }
        public ActionResult KaizenModalPopupPartial()
        {
            return PartialView("_KaizenModalPopupPartial");
        }
        public IActionResult NewKaizen()
		{
            try
            {
                //Guid id = Guid.NewGuid();// Sir Added Guid here for  Id
                //model.Id = id.ToString();
                // model.IEEmail = _infoSettings.IEEmail;
                //model.AccountEmail= _infoSettings.AccountEmail;

                model.IEEmail = conAccessor.HttpContext.Session.GetString("IEemail");
                model.AccountEmail = conAccessor.HttpContext.Session.GetString("FinanceEmail");
                model.name = conAccessor.HttpContext.Session.GetString("Message");
                model.EmpId = conAccessor.HttpContext.Session.GetString("EmpId");
                model.Domain = conAccessor.HttpContext.Session.GetString("Domain");
                model.Department = conAccessor.HttpContext.Session.GetString("Department");
                model.BlockList = _blockWorker.GetBlock();
                model.IEDepartList = _viewuserWorker.GetIEDepart();
                //model = _createNewKaizen.GetKaizenOriginatedby(model);
                DateTime currentDate  = DateTime.Today;
                model.OriginatedDate = currentDate.ToString("dd-MM-yyyy");
            }
            catch (Exception ex) { LogEvents.LogToFile(DbFiles.Title, ex.ToString()); }
            return View(model);
        }

        
        [HttpPost]
        [Route("CreateKaizen/NewKaizen")]
        public async Task<IActionResult> NewKaizen([FromForm] NewKaizenModel model)
        {
            string jsonMemberList = Request.Form["MemberList"].ToString();
            string jsonDepartList = Request.Form["DeploymentList"].ToString();
            // Deserialize JSON data
            var memberList = JsonConvert.DeserializeObject<List<TeamMemberDetails>>(jsonMemberList);
            var deploymentList = JsonConvert.DeserializeObject<List<DeploymentDetails>>(jsonDepartList);
            if (model.AttachmentBefore != null && model.AttachmentAfter != null && model.RootProblemAttachment != null)
            {
                model.AttachmentPaths.AttachmentBeforePath = SaveUploadedFile(model.AttachmentBefore, nameof(model.AttachmentBefore));
                model.AttachmentPaths.AttachmentAfterPath = SaveUploadedFile(model.AttachmentAfter, nameof(model.AttachmentAfter));
                model.AttachmentPaths.RootProblemAttachmentPath = SaveUploadedFile(model.RootProblemAttachment, nameof(model.RootProblemAttachment));
            }
            List< Attachmentsimg > imagesList = new List<Attachmentsimg>();
            for (int z = 0; z < 3; z++)
            {
                Attachmentsimg objAtt = new Attachmentsimg();
                objAtt.kaizenId = model.KaizenId;
                if (z == 0)
                    objAtt.FileName = model.AttachmentPaths.AttachmentBeforePath;
                else if (z == 1)
                    objAtt.FileName = model.AttachmentPaths.AttachmentAfterPath;
                else if (z == 2)
                    objAtt.FileName = model.AttachmentPaths.RootProblemAttachmentPath;
                objAtt.CreatedBy = model.CreatedBy;
                imagesList.Add(objAtt);
            }
            if (model.AdditionalAttachments != null && model.AdditionalAttachments.Count > 0)
            {
                foreach (var file in model.AdditionalAttachments)
                {
                    string propertyName = $"AdditionalAttachment_{model.AdditionalAttachments.IndexOf(file) + 1}";
                    string additionalPath =  SaveUploadedFile(file, propertyName);
                    Attachmentsimg objAtt = new Attachmentsimg();
                    objAtt.kaizenId = model.KaizenId;
                    objAtt.FileName = additionalPath;
                    objAtt.CreatedBy = model.CreatedBy;
                    imagesList.Add(objAtt);
                }
            }
            model.AttachmentsList = imagesList;
            model.DeploymentList = deploymentList;
            model.MemberList = memberList;
            model.insertStatus = false;
            Guid id = Guid.NewGuid();
            model.Id = id.ToString();
            string loginuserid= conAccessor.HttpContext.Session.GetString("UserID");
            if (model.MemberList != null)
            {
                model.MemberList.ForEach(m => m.KaizenId = id.ToString());
                model.MemberList.ForEach(m => m.CreatedBy = loginuserid.ToString());
            }
            if (model.DeploymentList != null)
            {
                model.DeploymentList.ForEach(m => m.KaizenId = id.ToString());
                model.DeploymentList.ForEach(m => m.CreatedBy = loginuserid.ToString());
            }
            if (model.AttachmentsList != null)
            {
                model.AttachmentsList.ForEach(m => m.kaizenId = id.ToString());
                model.AttachmentsList.ForEach(m => m.CreatedBy = loginuserid.ToString());
            }
            model.CreatedBy = conAccessor.HttpContext.Session.GetString("EmpId");
            model.insertStatus = _createNewKaizen.CreateNewKaizen(model);
            return Ok(new { success = true });
        }

        [HttpPost]
        [Route("CreateKaizen/SubmitKaizen")]
        public async Task<IActionResult> SubmitKaizen([FromForm] NewKaizenModel model)
        {
            string jsonMemberList = Request.Form["MemberList"].ToString();
            string jsonDepartList = Request.Form["DeploymentList"].ToString();
            // Deserialize JSON data
            var memberList = JsonConvert.DeserializeObject<List<TeamMemberDetails>>(jsonMemberList);
            var deploymentList = JsonConvert.DeserializeObject<List<DeploymentDetails>>(jsonDepartList);
            if (model.AttachmentBefore != null && model.AttachmentAfter != null && model.RootProblemAttachment != null)
            {
                model.AttachmentPaths.AttachmentBeforePath = SaveUploadedFile(model.AttachmentBefore, nameof(model.AttachmentBefore));
                model.AttachmentPaths.AttachmentAfterPath = SaveUploadedFile(model.AttachmentAfter, nameof(model.AttachmentAfter));
                model.AttachmentPaths.RootProblemAttachmentPath = SaveUploadedFile(model.RootProblemAttachment, nameof(model.RootProblemAttachment));
            }
            List<Attachmentsimg> imagesList = new List<Attachmentsimg>();
            for (int z = 0; z < 3; z++)
            {
                Attachmentsimg objAtt = new Attachmentsimg();
                objAtt.kaizenId = model.KaizenId;
                if (z == 0)
                    objAtt.FileName = model.AttachmentPaths.AttachmentBeforePath;
                else if (z == 1)
                    objAtt.FileName = model.AttachmentPaths.AttachmentAfterPath;
                else if (z == 2)
                    objAtt.FileName = model.AttachmentPaths.RootProblemAttachmentPath;
                objAtt.CreatedBy = model.CreatedBy;
                imagesList.Add(objAtt);
            }
            if (model.AdditionalAttachments != null && model.AdditionalAttachments.Count > 0)
            {
                foreach (var file in model.AdditionalAttachments)
                {
                    string propertyName = $"AdditionalAttachment_{model.AdditionalAttachments.IndexOf(file) + 1}";
                    string additionalPath = SaveUploadedFile(file, propertyName);
                    Attachmentsimg objAtt = new Attachmentsimg();
                    objAtt.kaizenId = model.KaizenId;
                    objAtt.FileName = additionalPath;
                    objAtt.CreatedBy = model.CreatedBy;
                    imagesList.Add(objAtt);
                }
            }
            model.AttachmentsList = imagesList;
            model.DeploymentList = deploymentList;
            model.MemberList = memberList;
            model.insertStatus = false;
            Guid id = Guid.NewGuid();
            model.Id = id.ToString();
            string loginuserid = conAccessor.HttpContext.Session.GetString("UserID");
            if (model.MemberList != null)
            {
                model.MemberList.ForEach(m => m.KaizenId = id.ToString());
                model.MemberList.ForEach(m => m.CreatedBy = loginuserid.ToString());
            }
            if (model.DeploymentList != null)
            {
                model.DeploymentList.ForEach(m => m.KaizenId = id.ToString());
                model.DeploymentList.ForEach(m => m.CreatedBy = loginuserid.ToString());
            }
            if (model.AttachmentsList != null)
            {
                model.AttachmentsList.ForEach(m => m.kaizenId = id.ToString());
                model.AttachmentsList.ForEach(m => m.CreatedBy = loginuserid.ToString());
            }
            model.CreatedBy = conAccessor.HttpContext.Session.GetString("EmpId");
            model.insertStatus = _createNewKaizen.SubmitKaizenDri(model);
            return Ok(new { success = true });
        }

        [HttpPost]
        public IActionResult GetTeamMemberDetails(NewKaizenModel model)
        {
            model = _createNewKaizen.GetKaizenOriginatedby(model);
            return Ok(model); 
		}
        public NewKaizenModel GetKaizendetailsById(string KaizenId)
        {
            NewKaizenModel viewModel = new NewKaizenModel();
            viewModel.KaizenList= _createNewKaizen.GetKaizenDetailsById(KaizenId);
            viewModel.TeamList = _createNewKaizen.GetTeamDetailsById(KaizenId);
            viewModel.ScopeList = _createNewKaizen.GetScopeDetailsById(KaizenId);
            viewModel.Approverslist= _createNewKaizen.GetApproversByID(KaizenId);
            HttpContext.Session.Remove("Kaizenid");
            HttpContext.Session.SetString("Kaizenid", KaizenId);
          viewModel.AttachmentsList= _createNewKaizen.GetImageListById(KaizenId);
            return viewModel;
        }

        [HttpPost]
        public IActionResult getstatus([FromBody] ApprovalRequest request) {
            request.kaizenID= conAccessor.HttpContext.Session.GetString("Kaizenid");          
            bool result = _createNewKaizen.updateKaizensatus(request);
            return Ok(result);
        }

        private string SaveUploadedFile(IFormFile file, string propertyName)
        {
            try
            {
                model.LogFilePath = _infoSettings.LogFilePath; // Update this to your desired path

                if (!Directory.Exists(model.LogFilePath))
                {
                    Directory.CreateDirectory(model.LogFilePath);
                }

                string uniqueFileName = $"{Guid.NewGuid()}_{propertyName}_{Path.GetFileName(file.FileName)}";
                string filePath = Path.Combine(model.LogFilePath, uniqueFileName);
                //string filePath = Path.Combine(uniqueFileName);

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

        [HttpPost]
        [Route("CreateKaizen/UpdateKaizen")]
        public async Task<IActionResult> UpdateKaizen([FromForm] NewKaizenModel model)
        {
            model.KaizenId = HttpContext.Session.GetString("Kaizenid");
            string jsonMemberList = Request.Form["MemberList"].ToString();
            string jsonDepartList = Request.Form["DeploymentList"].ToString();
            // Deserialize JSON data
            var memberList = JsonConvert.DeserializeObject<List<TeamMemberDetails>>(jsonMemberList);
         var deploymentList = JsonConvert.DeserializeObject<List<DeploymentDetails>>(jsonDepartList);
            if (model.AttachmentBefore != null)
            {
                model.AttachmentPaths.AttachmentBeforePath = SaveUploadedFile(model.AttachmentBefore, nameof(model.AttachmentBefore));
            }
            if (model.AttachmentAfter != null)
            {
                model.AttachmentPaths.AttachmentAfterPath = SaveUploadedFile(model.AttachmentAfter, nameof(model.AttachmentAfter));
            }
            if (model.RootProblemAttachment != null)
            {
                model.AttachmentPaths.RootProblemAttachmentPath = SaveUploadedFile(model.RootProblemAttachment, nameof(model.RootProblemAttachment));
            }
            List<Attachmentsimg> imagesList = new List<Attachmentsimg>();
            for (int z = 0; z < 3; z++)
            {
                Attachmentsimg objAtt = new Attachmentsimg();
                objAtt.kaizenId = model.KaizenId;
                if (z == 0)
                    objAtt.FileName = model.AttachmentPaths.AttachmentBeforePath;
                else if (z == 1)
                    objAtt.FileName = model.AttachmentPaths.AttachmentAfterPath;
                else if (z == 2)
                    objAtt.FileName = model.AttachmentPaths.RootProblemAttachmentPath;
                objAtt.CreatedBy = model.CreatedBy;
                imagesList.Add(objAtt);
            }
            if (model.AdditionalAttachments != null && model.AdditionalAttachments.Count > 0)
            {
                foreach (var file in model.AdditionalAttachments)
                {
                    string propertyName = $"AdditionalAttachment_{model.AdditionalAttachments.IndexOf(file) + 1}";
                    string additionalPath = SaveUploadedFile(file, propertyName);
                    Attachmentsimg objAtt = new Attachmentsimg();
                    objAtt.kaizenId = model.KaizenId;
                    objAtt.FileName = additionalPath;
                    objAtt.CreatedBy = model.CreatedBy;
                    imagesList.Add(objAtt);
                }
            }
            model.AttachmentsList = imagesList;
            model.DeploymentList = deploymentList;
            model.MemberList = memberList;
            model.insertStatus = false;
           
            string loginuserid = conAccessor.HttpContext.Session.GetString("UserID");
            if (model.MemberList != null)
            {
                model.MemberList.ForEach(m => m.KaizenId = model.Id.ToString());
                model.MemberList.ForEach(m => m.CreatedBy = loginuserid.ToString());
            }
            if (model.DeploymentList != null)
            {
                model.DeploymentList.ForEach(m => m.KaizenId = model.Id.ToString());
                model.DeploymentList.ForEach(m => m.CreatedBy = loginuserid.ToString());
            }
            if (model.AttachmentsList != null)
            {
                model.AttachmentsList.ForEach(m => m.kaizenId = model.Id.ToString());
                model.AttachmentsList.ForEach(m => m.CreatedBy = loginuserid.ToString());
            }
            model.CreatedBy = conAccessor.HttpContext.Session.GetString("EmpId");
            model.insertStatus = _createNewKaizen.UpdateNewKaizen(model);
            return Ok(new { success = true });
        }


        [HttpPost]
        [Route("CreateKaizen/UpdateSubmittedKaizen")]
        public async Task<IActionResult> UpdateSubmittedKaizen([FromForm] NewKaizenModel model)
        {
            model.KaizenId = HttpContext.Session.GetString("Kaizenid");
            string jsonMemberList = Request.Form["MemberList"].ToString();
            string jsonDepartList = Request.Form["DeploymentList"].ToString();
            // Deserialize JSON data
            var memberList = JsonConvert.DeserializeObject<List<TeamMemberDetails>>(jsonMemberList);
            //if (memberList[0].EmpId == "")

            //{
            //    memberList = _createNewKaizen.GetTeamDetailsUpdateById(model.KaizenId);
            //}

            var deploymentList = JsonConvert.DeserializeObject<List<DeploymentDetails>>(jsonDepartList);
            if (model.AttachmentBefore != null)
            {
                model.AttachmentPaths.AttachmentBeforePath = SaveUploadedFile(model.AttachmentBefore, nameof(model.AttachmentBefore));
            }
            if (model.AttachmentAfter != null)
            {
                model.AttachmentPaths.AttachmentAfterPath = SaveUploadedFile(model.AttachmentAfter, nameof(model.AttachmentAfter));
            }
            if (model.RootProblemAttachment != null)
            {
                model.AttachmentPaths.RootProblemAttachmentPath = SaveUploadedFile(model.RootProblemAttachment, nameof(model.RootProblemAttachment));
            }
            List<Attachmentsimg> imagesList = new List<Attachmentsimg>();
            for (int z = 0; z < 3; z++)
            {
                Attachmentsimg objAtt = new Attachmentsimg();
                objAtt.kaizenId = model.KaizenId;
                if (z == 0)
                    objAtt.FileName = model.AttachmentPaths.AttachmentBeforePath;
                else if (z == 1)
                    objAtt.FileName = model.AttachmentPaths.AttachmentAfterPath;
                else if (z == 2)
                    objAtt.FileName = model.AttachmentPaths.RootProblemAttachmentPath;
                objAtt.CreatedBy = model.CreatedBy;
                imagesList.Add(objAtt);
            }
            if (model.AdditionalAttachments != null && model.AdditionalAttachments.Count > 0)
            {
                foreach (var file in model.AdditionalAttachments)
                {
                    string propertyName = $"AdditionalAttachment_{model.AdditionalAttachments.IndexOf(file) + 1}";
                    string additionalPath = SaveUploadedFile(file, propertyName);
                    Attachmentsimg objAtt = new Attachmentsimg();
                    objAtt.kaizenId = model.KaizenId;
                    objAtt.FileName = additionalPath;
                    objAtt.CreatedBy = model.CreatedBy;
                    imagesList.Add(objAtt);
                }
            }
            model.AttachmentsList = imagesList;
            model.DeploymentList = deploymentList;
            model.MemberList = memberList;
            model.insertStatus = false;

            string loginuserid = conAccessor.HttpContext.Session.GetString("UserID");
            if (model.MemberList != null)
            {
                model.MemberList.ForEach(m => m.KaizenId = model.Id.ToString());
                model.MemberList.ForEach(m => m.CreatedBy = loginuserid.ToString());
            }
            if (model.DeploymentList != null)
            {
                model.DeploymentList.ForEach(m => m.KaizenId = model.Id.ToString());
                model.DeploymentList.ForEach(m => m.CreatedBy = loginuserid.ToString());
            }
            if (model.AttachmentsList != null)
            {
                model.AttachmentsList.ForEach(m => m.kaizenId = model.Id.ToString());
                model.AttachmentsList.ForEach(m => m.CreatedBy = loginuserid.ToString());
            }
            model.CreatedBy = conAccessor.HttpContext.Session.GetString("EmpId");
            model.insertStatus = _createNewKaizen.UpdateSubmittedKaizen(model);
            return Ok(new { success = true });
        }

        [HttpPost]
        public JsonResult DeleteKaizen(string id, string Attachmentid)
        {
            try
            {
                DataTable dataTable = _createNewKaizen.GetAttachmentsByIdfordelete(id, Attachmentid);
                List<Attachmentsimg> attachments = new List<Attachmentsimg>();
                foreach (DataRow row in dataTable.Rows)
                {
                    attachments.Add(new Attachmentsimg
                    {
                        FileName = row["FileName"].ToString()
                    });
                }
                foreach (var attachment in attachments)
                {
                    string pathforAttachments = _infoSettings.LogFilePath;
                    /*string attachmentPath = Path.Combine("C:\\Uploads-images\\images", attachment.FileName);*/
                    string attachmentPath = Path.Combine("pathforAttachments", attachment.FileName); 
                    if (System.IO.File.Exists(attachmentPath))
                    {
                        System.IO.File.Delete(attachmentPath);
                    }
                    _createNewKaizen.RemoveAttachment(attachment,id);
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }



    }
}
