using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Kaizen.Business.Interface;
using Kaizen.Models.ReportModel;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
//using NPOI.POIFS.Storage;
using Kaizen.Data.Constant;
using Kaizen.Business.Worker;
using Kaizen.Models.DashboardModel;
using Microsoft.AspNetCore.Authorization;

namespace Kaizen.Web.Controllers
{
    [Authorize(Roles = "ADM")]
    public class ReportsController : Controller
    {
        private readonly IReport _downloadexcel;
        private readonly IDashboard _dashboardworker;

        public ReportsController(IReport reportworker, IDashboard dashboardworker)
        {
            _downloadexcel = reportworker;
            _dashboardworker = dashboardworker;
        }

        public IActionResult ReportDownload()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult KaizenForm(KaizenReportModel model)
        {
            try
            {
                var list = _downloadexcel.GetKaizenform(model);
                return File(_downloadexcel.ExportDataTableToExcel(list), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "KaizenReport.xlsx");
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }
        [HttpGet]
        public IActionResult BlockForm(KaizenReportModel model)
        {
            try
            {
                var list = _downloadexcel.GetBlockReport(model);
                return File(_downloadexcel.ExportDataTableToExcel(list), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BlockReport.xlsx");
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }
        [HttpGet]
        public IActionResult DomainForm(KaizenReportModel model)
        {
            try
            {
                var list = _downloadexcel.GetDomainReport(model);
                return File(_downloadexcel.ExportDataTableToExcel(list), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DepartmentReport.xlsx");
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }
        [HttpGet]
        public IActionResult DepartmentForm(KaizenReportModel model)
        {
            try
            {
                var list = _downloadexcel.GetDepartmentReport(model);
                return File(_downloadexcel.ExportDataTableToExcel(list), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Sub-DepartmentReport.xlsx");
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }
        [HttpGet]
        public IActionResult UserForm(KaizenReportModel model)
        {
            try
            {
                var list = _downloadexcel.GetUsersReport(model);
                return File(_downloadexcel.ExportDataTableToExcel(list), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UserReport.xlsx");
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }

        [HttpGet]
        public IActionResult UserlogForm(KaizenReportModel model)
        {
            try
            {
                var list = _downloadexcel.GetUserLogform(model);
                return File(_downloadexcel.ExportDataTableToExcel(list), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UserLogReport.xlsx");
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }

        //Dashboard Reports
        [HttpGet]
        public IActionResult DasboardBlocks(string? StartDate, string? EndDate)
        {
           

            try
            {
                DashboardModel model = new DashboardModel()
                {
                    StartDate = StartDate,
                    EndDate = EndDate,
                };
                var list = _downloadexcel.DashboardBlockReport(model);
                return File(_downloadexcel.ExportDataTableToExcel(list), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UserReport.xlsx");
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }
        [HttpGet]
        public IActionResult DasboardCadre(string? StartDate, string? EndDate)
        {
            try
            {
                DashboardModel model = new DashboardModel()
                {
                    StartDate = StartDate,
                    EndDate = EndDate,
                };
                var list = _downloadexcel.DashboardCadreReport(model);
                return File(_downloadexcel.ExportDataTableToExcel(list), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UserReport.xlsx");
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }
        [HttpGet]
        public IActionResult DasboardDomain(string? StartDate, string? EndDate)
        {
            try
            {
                DashboardModel model = new DashboardModel()
                {
                    StartDate = StartDate,
                    EndDate = EndDate,
                };
                var list = _downloadexcel.DashboardDomainReport(model);
                return File(_downloadexcel.ExportDataTableToExcel(list), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UserReport.xlsx");
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }
        [HttpGet]
        public IActionResult DasboardDepartment(string? StartDate, string? EndDate,string Domain)
        {
            try
            {
                DashboardModel model = new DashboardModel()
                {
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Domain = Domain
                };
                var list = _downloadexcel.DashboardDepartmentReport(model);
                return File(_downloadexcel.ExportDataTableToExcel(list), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UserReport.xlsx");
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }
    }
}
