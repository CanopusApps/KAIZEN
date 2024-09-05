using Kaizen.Business.Interface;
using Kaizen.Data.Constant;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Xml.Linq;
using Kaizen.Web;
using System.Reflection.Metadata;
using Kaizen.Models.ViewUserModel;
using Kaizen.Models.AdminModel;
using Kaizen.Business.Worker;
using static System.Reflection.Metadata.BlobBuilder;
using Kaizen.Models.SubmmitedKaizen;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Kaizen.Web.Controllers
{
    public class SubmittedKaizenController : Controller
    {
        public IHttpContextAccessor conAccessor;
        private readonly IDomain _domainWorker;
        private readonly IDepartment   _departmentWorker;
        private readonly ISubmittedKaizen _submittedKaizenWorker;
        private readonly IWebHostEnvironment _environment;
        string ImageApprover;
        public SubmittedKaizenController(IDomain domainWorker,IDepartment departmentWorker, ISubmittedKaizen submittedKaizenWorker, IHttpContextAccessor conAccessor)
        {
            _domainWorker = domainWorker;
            _departmentWorker = departmentWorker;
            _submittedKaizenWorker = submittedKaizenWorker;
            this.conAccessor = conAccessor;
        }

        public IActionResult ViewKaizen(string? StartDate, string? EndDate, string? Domain, string? Department, string? KaizenTheme, string? Status)
        {
            SubmittedKaizenallModel viewModel = new SubmittedKaizenallModel();
            try
            {
                viewModel.DomainList = _domainWorker.GetDomain().Where(d => d.Status == true).ToList();
                KaizenListModel model = new KaizenListModel()
                {
                    StartDate=StartDate,
                    EndDate=EndDate,
                    Domain=Domain,
                    Department=Department,
                    KaizenTheme=KaizenTheme,
                    Status=Status,
                    role= conAccessor.HttpContext.Session.GetString("Userrole"),
                    UserId = conAccessor.HttpContext.Session.GetString("UserID")
                };
                var SubmittedKaizenList = _submittedKaizenWorker.GetKaizenList(model);
                viewModel.SubmittedKaizenList = SubmittedKaizenList.Where(K => K.AStatus != 14).ToList();
                var formattedList = viewModel.SubmittedKaizenList.Select(theme => new { label = theme.KaizenTheme, val = theme.KaizenId }).ToList();
                ViewBag.FormattedList = formattedList;
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString()); 
            }
            return View(viewModel);
        }
        public IActionResult ViewFilterKaizen(string? StartDate, string? EndDate, string? Domain, string? Department, string? KaizenTheme, string? Status,string? benifitarea)
        {
            KaizenListModel model = new KaizenListModel()
            {
                StartDate = StartDate,
                EndDate = EndDate,
                Domain = Domain,
                Department = Department,
                KaizenTheme = KaizenTheme,
                Status = (Status == "Rejected" || Status == "Pending") ? null : Status,
                role = conAccessor.HttpContext.Session.GetString("Userrole"),
                UserId = conAccessor.HttpContext.Session.GetString("UserID"),
                BenefitArea = benifitarea
            };
            var SubmittedKaizenList = _submittedKaizenWorker.GetKaizenList(model);
            //SubmittedKaizenList = SubmittedKaizenList.Where(K => K.AStatus != 14).ToList();
            try
            {

                if (Status == "Rejected")
                {
                    var targetStatuses = new List<int> { 3, 5, 7, 9 };
                    //SubmittedKaizenList = SubmittedKaizenList.Where(K => targetStatuses.Contains(K.AStatus)).ToList();
                    SubmittedKaizenList = SubmittedKaizenList
                      .Where(K => K.AStatus != null && targetStatuses.Contains((int)K.AStatus))
                      .ToList();
                }
                if (Status == "Pending")
                {
                    var targetStatuses = new List<int> { 1, 2, 4, 6, 15 };
                    //SubmittedKaizenList = SubmittedKaizenList.Where(K => targetStatuses.Contains(K.AStatus)).ToList();
                    SubmittedKaizenList = SubmittedKaizenList.Where(K => K.AStatus != null && targetStatuses.Contains((int)K.AStatus) && K.ApprovalStatus != "Approved Kaizen").ToList();
                }
                else
                {
                    // Filter where AStatus is not equal to 14
                    SubmittedKaizenList = SubmittedKaizenList.Where(K => K.AStatus != 14).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return PartialView("_SubmittedKaizenGridPartial", SubmittedKaizenList);
        }
        public List<DepartmentModel> FetchDepartment(string domainid)
        {
            List<DepartmentModel> deptList = new List<DepartmentModel>();
            try
            {
                if (!string.IsNullOrEmpty(domainid))
                {
                    deptList = _departmentWorker.GetDepartments().Where(d => d.DomainId == Convert.ToInt32(domainid)).ToList();

                }
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());

            }
            return deptList;
        }
        public List<ApprovalStatusModel> ApprovalStatusList()
        {
            List<ApprovalStatusModel> list = new List<ApprovalStatusModel>();
            try
            {
                string UserType;
                UserType = conAccessor.HttpContext.Session.GetString("Userrole");
                list = _submittedKaizenWorker.GetApprovalStatus(UserType);
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                
            }

            return list;
        }
        public IActionResult DeleteKaizen(int KaizenId)
        {
            string UserId="";
            bool deleteStatus = false;
            try
            {
                UserId = conAccessor.HttpContext.Session.GetString("UserID");
                deleteStatus = _submittedKaizenWorker.DeleteKaizen(KaizenId, UserId);
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());

            }
            return Ok(deleteStatus);
        }
        public IActionResult FetchKaizenDetails_by_CreatedBy(string? UserId,string? role,string? LoginRole)
        {
            List<KaizenListModel> SubmittedKaizenList = new List<KaizenListModel>();
            try
            {
                KaizenListModel model = new KaizenListModel()
                {
                    role = role,
                    UserId = UserId
                };
                SubmittedKaizenList = _submittedKaizenWorker.GetKaizenList(model);
                if (LoginRole == "ADM")
                {
                    // Exclude items with status 0
                    SubmittedKaizenList = SubmittedKaizenList.Where(k => k.ApprovalStatus != "Saved").ToList();
                }
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return StatusCode(500, "An error occurred while fetching Kaizen details."); // or another appropriate response
            }
            return PartialView("_SubmittedKaizenGridPartial", SubmittedKaizenList);
        }
        public IActionResult ViewImageApproval(string? StartDate, string? EndDate, string? Domain, string? Department, string? KaizenTheme, string? Status)
        {
            SubmittedKaizenallModel viewModel = new SubmittedKaizenallModel();
            try
            {
                ImageApprover = conAccessor.HttpContext.Session.GetString("ImageApprover");
                viewModel.DomainList = _domainWorker.GetDomain().Where(d => d.Status == true).ToList();
                KaizenListModel model = new KaizenListModel()
                {
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Domain = Domain,
                    Department = Department,
                    KaizenTheme = KaizenTheme,
                    Status = Status,
                    role = ImageApprover,
                    UserId = conAccessor.HttpContext.Session.GetString("UserID")
                };
                var SubmittedKaizenList = _submittedKaizenWorker.GetKaizenList(model);
                viewModel.SubmittedKaizenList = SubmittedKaizenList.Where(K => K.AStatus == 1).ToList();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString()); 
            }
            return View(viewModel);
        }
        public IActionResult ViewFilterImageApproval(string? StartDate, string? EndDate, string? Domain, string? Department, string? KaizenTheme, string? Status)
        {
            List<KaizenListModel> SubmittedKaizenList = new List<KaizenListModel>();
            try
            {
                ImageApprover = conAccessor.HttpContext.Session.GetString("ImageApprover");
                KaizenListModel model = new KaizenListModel()
                {
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Domain = Domain,
                    Department = Department,
                    KaizenTheme = KaizenTheme,
                    Status = Status,
                    role = ImageApprover,
                    UserId = conAccessor.HttpContext.Session.GetString("UserID")
                };
                SubmittedKaizenList = _submittedKaizenWorker.GetKaizenList(model);///
                SubmittedKaizenList = SubmittedKaizenList.Where(K => K.AStatus == 1).ToList();
            }
            catch (Exception ex)
            {

                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return StatusCode(500, "An error occurred while filtering the Kaizen list."); // or another appropriate response
            }
            return PartialView("_SubmittedKaizenGridPartial", SubmittedKaizenList);
        }
        public IActionResult DeletedKaizen()
        {
            SubmittedKaizenallModel viewModel = new SubmittedKaizenallModel();
            try
            {

                KaizenListModel model = new KaizenListModel()
                {
                    role = conAccessor.HttpContext.Session.GetString("Userrole"),
                    UserId = conAccessor.HttpContext.Session.GetString("UserID")
                };
                var SubmittedKaizenList = _submittedKaizenWorker.GetKaizenList(model);
                viewModel.SubmittedKaizenList = SubmittedKaizenList.Where(K => K.AStatus == 14).ToList();
            }
            catch (Exception ex)
            {
               
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());

                viewModel.SubmittedKaizenList = new List<KaizenListModel>(); // or another appropriate response
            }

            return View(viewModel);
        }
        
    }
}
