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
using System.Drawing.Imaging;
using System.Drawing;
using GemBox.Spreadsheet.Drawing;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Org.BouncyCastle.Utilities;

namespace Kaizen.Web.Controllers
{
    public class CreateKaizenController : Controller
    {
        public IHttpContextAccessor conAccessor;
        private readonly IBlock _blockWorker;
        private readonly IViewuser _viewuserWorker;
        private readonly ICreateNewKaizen _createNewKaizen;
        private readonly ILogin _loginworker;
        //private readonly string _uploadspath;
        private readonly NewKaizenModel _infoSettings;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment env;

        NewKaizenModel model = new NewKaizenModel();

        public CreateKaizenController(IBlock worker, IViewuser viewuserworker  , ICreateNewKaizen kaizenWorker, IHttpContextAccessor conAccessor, IOptions<NewKaizenModel> infoSettings, ILogin loginworker)
        {
            _blockWorker = worker;
            _viewuserWorker = viewuserworker;
            _createNewKaizen = kaizenWorker;
            this.conAccessor = conAccessor;
            _infoSettings = infoSettings.Value;
            _loginworker = loginworker;
            this.env = env;

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
                var activeBlocks = _blockWorker.GetBlock().Where(d => d.Status == true).ToList();
                model.IEEmail = conAccessor.HttpContext.Session.GetString("IEemail");
                model.AccountEmail = conAccessor.HttpContext.Session.GetString("FinanceEmail");
                model.name = conAccessor.HttpContext.Session.GetString("Message");
                model.EmpId = conAccessor.HttpContext.Session.GetString("EmpId");
                model.Domain = conAccessor.HttpContext.Session.GetString("Domain");
                model.Department = conAccessor.HttpContext.Session.GetString("Department");
                model.BlockList = activeBlocks;
                model.IEDepartList = _viewuserWorker.GetIEDepart();
                model.FinanceList = _viewuserWorker.GetFinance();
                var managerupt = conAccessor.HttpContext.Session.GetString("DepartmentId");
                    model.ManagerList = _loginworker.Usermanager1(managerupt);
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
            try
            {
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
            catch (Exception ex)
            {
                // Log the exception
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());

                // Return a 500 status code with an error message
                return StatusCode(500, new { success = false, message = "An error occurred while creating the Kaizen." });
            }

        }


        [HttpPost]
        [Route("CreateKaizen/SubmitKaizen")]
        public async Task<IActionResult> SubmitKaizen([FromForm] NewKaizenModel model)
        {
            try
            {
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
            catch (Exception ex)
            {
                // Log the exception
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());

                // Return a 500 status code with an error message
                return StatusCode(500, new { success = false, message = "An error occurred while submitting the Kaizen." });
            }
        }

        [HttpPost]
        public IActionResult GetTeamMemberDetails(NewKaizenModel model)
        {
            try
            {
                var empIdFromSession = HttpContext.Session.GetString("EmpId");

                if (model.EmpId == empIdFromSession)
                {
                    return BadRequest("User cannot be added as a Team Member again");
                }
                model = _createNewKaizen.GetKaizenOriginatedby(model);
                if (model.Usertype == "ADM")
                {
                    return BadRequest("Admin can't be added as a Team Menber ");
                }
                if (model.Usertype == "FIN")
                {
                    return BadRequest("Finance can't be added as a Team Menber ");
                }
                if (model.Usertype == "IED")
                {
                    return BadRequest("IE DEPT can't be added as a Team Menber ");
                }
                return Ok(model);
            }
             catch (Exception ex)
                {
                // Log the exception
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());

                // Return a 500 status code with an error message
                return StatusCode(500, new { success = false, message = "An error occurred while processing the request." });
                }
		}
        public NewKaizenModel GetKaizendetailsById(string KaizenId)
        {
            NewKaizenModel viewModel = new NewKaizenModel();
            try
            {
                viewModel.KaizenList = _createNewKaizen.GetKaizenDetailsById(KaizenId);
                var managerupt = viewModel.KaizenList[0].Department;
                viewModel.ManagerupdateList = _createNewKaizen.Usermanagerforedit(managerupt) ?? new List<ManagerModelUpdate>();
                viewModel.TeamList = _createNewKaizen.GetTeamDetailsById(KaizenId);
                viewModel.ScopeList = _createNewKaizen.GetScopeDetailsById(KaizenId);
                viewModel.Approverslist = _createNewKaizen.GetApproversByID(KaizenId);
                HttpContext.Session.Remove("Kaizenid");
                HttpContext.Session.SetString("Kaizenid", KaizenId);
                viewModel.AttachmentsList = _createNewKaizen.GetImageListById(KaizenId);
               
            }
            catch (Exception ex)
            {
                // Log the exception
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
            }
            return viewModel;
        }

        [HttpPost]
        public IActionResult getstatus([FromBody] ApprovalRequest request)
        {

            try
            {
                request.kaizenID = conAccessor.HttpContext.Session.GetString("Kaizenid");
                string empid = conAccessor.HttpContext.Session.GetString("EmpId");
                bool result = _createNewKaizen.updateKaizensatus(request, empid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                // Return an error response
                return StatusCode(500, "An error occurred while processing the request.");
            }
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
            try
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
            catch (Exception ex)
            {
                // Log the exception
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());

                // Return an error response
                return StatusCode(500, "An error occurred while updating the Kaizen.");
            }
        }


        [HttpPost]
        [Route("CreateKaizen/UpdateSubmittedKaizen")]
        public async Task<IActionResult> UpdateSubmittedKaizen([FromForm] NewKaizenModel model)
        {
            try
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

                model.UpdateAttachmentsList = _createNewKaizen.GetImageListById(model.KaizenId);
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
            catch (Exception ex)
            {
                // Log the exception
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());

                // Return an error response
                return StatusCode(500, "An error occurred while updating the submitted Kaizen.");
            }
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
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return Json(new { success = false, message = ex.Message });
            }
        }

        public IActionResult DownloadCertificate(string OriginatedByName,string OriginatedByDept)
        {
            //model.name = System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(OriginatedByName); 
            model.name = OriginatedByName.ToUpper();
            model.Department = OriginatedByDept;
            model.CertificateCreatedDate = DateTime.Now.ToString("dd/MM/yyyy");
            string imageFilePath = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\assets\img\Tata Electronic Certificate.jpg"}";
            string imageFilePath1 = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\assets\img\Tata Electronic CertificateNew.jpg"}";
            try
            {
                PointF Title = new PointF(315f, 436f);
                PointF firstLocation = new PointF(670f, 436f);
                PointF secondLocation = new PointF(450f, 530f);
                PointF thirdLocation = new PointF(955f, 530f);
                Bitmap bitmap = (Bitmap)Image.FromFile(imageFilePath);//load the image file
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font arialFont = new Font("CalibriLight", 13,FontStyle.Bold))
                    {
                        graphics.DrawString("Mr/Mrs  ", arialFont, Brushes.Black, Title);
                        graphics.DrawString(model.name, arialFont, Brushes.Black,  firstLocation);
                    }
                    using (Font arialFont = new Font("CalibriLight", 10))
                    {
                        graphics.DrawString(model.Department, arialFont, Brushes.Black, secondLocation);
                        graphics.DrawString(model.CertificateCreatedDate, arialFont, Brushes.Black, thirdLocation);
                    }
                }
                bitmap.Save(imageFilePath1, ImageFormat.Jpeg);//save the image file
                           }
            catch(Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                //return Json(new { success = false });
                return Json(new { error = "An error occurred while processing your request." });
            }
            byte[] bytes = System.IO.File.ReadAllBytes(imageFilePath1);
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AppreciationCertificate-" + model.name + ".jpg");
            //  return File(bytes, "image/jpg", imageFilePath1);
        }








    }
}
