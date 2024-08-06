﻿using Kaizen.Business.Interface;
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

namespace Kaizen.Web.Controllers
{
    public class SubmittedKaizenController : Controller
    {
        public IHttpContextAccessor conAccessor;
        private readonly IDomain _domainWorker;
        private readonly IDepartment   _departmentWorker;
        private readonly ISubmittedKaizen _submittedKaizenWorker;
        private readonly IWebHostEnvironment _environment;
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
                viewModel.DomainList = _domainWorker.GetDomain();
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
                viewModel.SubmittedKaizenList = _submittedKaizenWorker.GetKaizenList(model);
            }
            catch (Exception ex)
            {
                //LogEvents.LogToFile(DbFiles.Title, ex.ToString(), _environment); 
            }
            return View(viewModel);
        }
        public IActionResult ViewFilterKaizen(string? StartDate, string? EndDate, string? Domain, string? Department, string? KaizenTheme, string? Status)
        {
            KaizenListModel model = new KaizenListModel()
            {
                StartDate = StartDate,
                EndDate = EndDate,
                Domain = Domain,
                Department = Department,
                KaizenTheme = KaizenTheme,
                Status = Status,
                role = conAccessor.HttpContext.Session.GetString("Userrole"),
                UserId = conAccessor.HttpContext.Session.GetString("UserID")
            };
            var SubmittedKaizenList = _submittedKaizenWorker.GetKaizenList(model);///
            return PartialView("_SubmittedKaizenGridPartial", SubmittedKaizenList);
        }
        public List<DepartmentModel> FetchDepartment(string domainid)
        {
            List<DepartmentModel> deptList = new List<DepartmentModel>();
            if (!string.IsNullOrEmpty(domainid))
            {
                deptList = _departmentWorker.GetDepartments().Where(d => d.DomainId == Convert.ToInt32(domainid)).ToList();

            }
            return deptList;
        }
        public List<ApprovalStatusModel> ApprovalStatusList()
        {
            string UserType;
            List<ApprovalStatusModel> list = new List<ApprovalStatusModel>();
            UserType = conAccessor.HttpContext.Session.GetString("Userrole");
            list = _submittedKaizenWorker.GetApprovalStatus(UserType);
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
            KaizenListModel model = new KaizenListModel()
            {
                role = role,
                UserId = UserId
            };
            var SubmittedKaizenList = _submittedKaizenWorker.GetKaizenList(model);
            if (LoginRole == "ADMIN")
            {
                // Exclude items with status 0
                SubmittedKaizenList = SubmittedKaizenList.Where(k => k.ApprovalStatus != "Saved").ToList();
            }
            return PartialView("_SubmittedKaizenGridPartial", SubmittedKaizenList);
        }
    }
}
