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
using System.Globalization;

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
        //This function is used to display Submitted kaizen List on Page load .
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
                var Useridd = conAccessor.HttpContext.Session.GetString("UserID");
                var Loginrole = conAccessor.HttpContext.Session.GetString("Userrole");
                var LgnDomain = conAccessor.HttpContext.Session.GetString("Domain");
                var LgnDepartment = conAccessor.HttpContext.Session.GetString("Department");
                if (Loginrole =="MGR")
                {
                    viewModel.SubmittedKaizenList = SubmittedKaizenList.Where(K => K.AStatus != 14 && K.PostedBy!= Useridd && K.Domain == LgnDomain && K.Department == LgnDepartment).ToList();
                }
                else { 
                viewModel.SubmittedKaizenList = SubmittedKaizenList.Where(K => K.AStatus != 14).ToList();
                }
                var formattedList = viewModel.SubmittedKaizenList.Select(theme => new { label = theme.KaizenTheme, val = theme.KaizenId }).ToList();
                ViewBag.FormattedList = formattedList;
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString()); 
            }
            return View(viewModel);
        }
        //This function is used to filter Submitted Kaizen List as per Passing Paramters .
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
            var Useridd = conAccessor.HttpContext.Session.GetString("UserID");
            var Loginrole = conAccessor.HttpContext.Session.GetString("Userrole");
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
                    var LgnDomain = conAccessor.HttpContext.Session.GetString("Domain");
                    var LgnDepartment = conAccessor.HttpContext.Session.GetString("Department");
                    if (Loginrole == "MGR")
                    {
                        SubmittedKaizenList = SubmittedKaizenList.Where(K => K.AStatus != 14 && K.AStatus != 0 && K.PostedBy != Useridd && K.Domain == LgnDomain && K.Department == LgnDepartment).ToList();
                    }

                    else
                    {
                        // Filter where AStatus is not equal to 14
                        SubmittedKaizenList = SubmittedKaizenList.Where(K => K.AStatus != 14 && K.AStatus != 0).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return PartialView("_SubmittedKaizenGridPartial", SubmittedKaizenList);
        }

        public IActionResult ViewFilterKaizenCreatedbyDRI(string? StartDate, string? EndDate, string? Domain, string? Department, string? KaizenTheme, string? Status, string? benifitarea)
        {
            KaizenListModel model = new KaizenListModel()
            {
                StartDate = StartDate,
                EndDate = EndDate,
                Domain = Domain,
                Department = Department,
                KaizenTheme = KaizenTheme,
                Status = (Status == "Rejected" || Status == "Pending"||Status == "totaldricreated") ? null : Status,
                role = conAccessor.HttpContext.Session.GetString("Userrole"),
                UserId = conAccessor.HttpContext.Session.GetString("UserID"),
                BenefitArea = benifitarea
            };
            var Useridd = conAccessor.HttpContext.Session.GetString("UserID");
            var Loginrole = conAccessor.HttpContext.Session.GetString("Userrole");
            var SubmittedKaizenList = _submittedKaizenWorker.GetKaizenList(model);
            //SubmittedKaizenList = SubmittedKaizenList.Where(K => K.AStatus != 14).ToList();
            try
            {

                if (Loginrole == "MGR"&& Status== "totaldricreated")
                {
                    SubmittedKaizenList = SubmittedKaizenList.Where(K => K.AStatus != 14 && K.AStatus != 0 && K.PostedBy == Useridd).ToList();
                }else if (Loginrole == "MGR")
                    {
                        SubmittedKaizenList = SubmittedKaizenList.Where(K => K.AStatus != 14 && K.PostedBy == Useridd).ToList();
                    }

            }
            catch (Exception ex)
            {

            }
            return PartialView("_SubmittedKaizenGridPartial", SubmittedKaizenList);
        }





        // This function is used to filter based on Status, such as Block Name, Department Name, Cadre, Pending, Approved, and Rejected statuses when a Dashboard card is clicked.
        public IActionResult ViewFilterKaizenonclickDashboard(string? StartDate, string? EndDate, string? Domain, string? Department, string? cadre, string? Status, string? Block)
        {
            KaizenListModel model = new KaizenListModel()
            {
                StartDate = StartDate,
                EndDate = EndDate,
                Domain = Domain,
                Department = Department,
                Block = Block,
                Status = (Status == "Rejected" ||Status == "Total") ? null : Status,               
                role = conAccessor.HttpContext.Session.GetString("Userrole"),
                UserId = conAccessor.HttpContext.Session.GetString("UserID"),
                Cadre = cadre
            };
            var SubmittedKaizenList = _submittedKaizenWorker.GetKaizenListOnclickdashboard(model);
          
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
                        SubmittedKaizenList = SubmittedKaizenList.Where(K => K.AStatus != 14 && K.AStatus != 0).ToList();
                 
                }
            }
            catch (Exception ex)
            {

            }
            return PartialView("_SubmittedKaizenGridPartial", SubmittedKaizenList);
        }
        //This function is used to Fetch Department as per Domain id .
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
        //This Function is used to fetch ApprovalStatus list as per Role .
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
        //This Function is used to delete kaizen as per KaizenId.
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
        //Action method to display Kaizen list submitted by the perticular user.
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
        //Action method to display a list of Kaizens for image approval .
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
                var formattedList = viewModel.SubmittedKaizenList.Select(theme => new { label = theme.KaizenTheme, val = theme.KaizenId }).ToList();
                ViewBag.FormattedList = formattedList;
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString()); 
            }
            return View(viewModel);
        }
        //Action method to filter and display a list of Kaizens for image approval based on various search criteria.
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
        //This Action Method is Used to Return Deleted Kaizen List .
        //public IActionResult DeletedKaizen()
        //{
        //    SubmittedKaizenallModel viewModel = new SubmittedKaizenallModel();
        //    try
        //    {

        //        KaizenListModel model = new KaizenListModel()
        //        {
        //            role = conAccessor.HttpContext.Session.GetString("Userrole"),
        //            UserId = conAccessor.HttpContext.Session.GetString("UserID")
        //        };
        //        var SubmittedKaizenList = _submittedKaizenWorker.GetKaizenList(model);
        //        viewModel.SubmittedKaizenList = SubmittedKaizenList.Where(K => K.AStatus == 14).ToList();
        //    }
        //    catch (Exception ex)
        //    {

        //        LogEvents.LogToFile(DbFiles.Title, ex.ToString());

        //        viewModel.SubmittedKaizenList = new List<KaizenListModel>(); // or another appropriate response
        //    }

        //    return View(viewModel);
        //}

            public IActionResult DeletedKaizen(DateTime? startDate, DateTime? endDate)
            {
                SubmittedKaizenallModel viewModel = new SubmittedKaizenallModel();
                try
                {
                    KaizenListModel model = new KaizenListModel()
                    {
                        role = conAccessor.HttpContext.Session.GetString("Userrole"),
                        UserId = conAccessor.HttpContext.Session.GetString("UserID")
                    };

                    // Get the submitted Kaizen list
                    var SubmittedKaizenList = _submittedKaizenWorker.GetKaizenList(model);

                // Filter the SubmittedKaizenList for deleted status (AStatus == 14)
                var filteredKaizenList = SubmittedKaizenList
                    .Where(K => K.AStatus == 14);

                // Further filter based on startDate and endDate
                if (startDate.HasValue || endDate.HasValue)
                {
                    filteredKaizenList = filteredKaizenList
                        .Where(K =>
                            (!startDate.HasValue || (DateTime.TryParseExact(K.CreatedDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime createdDate) && createdDate >= startDate.Value)) &&
                            (!endDate.HasValue || (DateTime.TryParseExact(K.CreatedDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out createdDate) && createdDate <= endDate.Value)));
                }
                // DEBUG: Check if dates are filtering correctly
                if (!filteredKaizenList.Any())
                {
                    LogEvents.LogToFile("DeletedKaizen", $"No records found for startDate: {startDate}, endDate: {endDate}");
                }

                // Assign the filtered list to the view model
                viewModel.SubmittedKaizenList = filteredKaizenList.ToList();
            }
                catch (Exception ex)
                {
                    LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                    viewModel.SubmittedKaizenList = new List<KaizenListModel>(); // or another appropriate response
                }

            return View(viewModel);
        }

   
        public IActionResult Dricreatedkaizens()
        {
            SubmittedKaizenallModel viewModel = new SubmittedKaizenallModel();
            try
            {

                KaizenListModel model = new KaizenListModel()
                {
                    role = conAccessor.HttpContext.Session.GetString("Userrole"),
                    UserId = conAccessor.HttpContext.Session.GetString("UserID")
                };
                var Useridd = conAccessor.HttpContext.Session.GetString("UserID");
                var SubmittedKaizenList = _submittedKaizenWorker.GetKaizenList(model);
                viewModel.SubmittedKaizenList = SubmittedKaizenList.Where(K => K.PostedBy == Useridd).ToList();
                var formattedList = viewModel.SubmittedKaizenList.Select(theme => new { label = theme.KaizenTheme, val = theme.KaizenId }).ToList();
                ViewBag.FormattedList = formattedList;
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
