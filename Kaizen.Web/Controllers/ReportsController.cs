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

namespace Kaizen.Web.Controllers
{
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
                return File(_downloadexcel.ExportDataTableToExcel(list), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DomainReport.xlsx");
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
                return File(_downloadexcel.ExportDataTableToExcel(list), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DepartmentReport.xlsx");
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

        //Dashboard Reports
        [HttpGet]
        public IActionResult DasboardBlocks(string? StartDate, string? EndDate)
        {
            DashboardModel model = new DashboardModel()
            {
                StartDate = StartDate,
                EndDate = EndDate,
            };

            try
            {
                // Get the list of data
                var list = _dashboardworker.kaizenCountbasedonBlocks(model)
                    .Select(item => new
                    {
                        Blockid = item.Blockid,
                        Blockname = item.Blockname,
                        TotalKaizensubmitted = item.TotalSubmittedKaizen
                    }).ToList();

                // Export to Excel and return the file
                return File(_downloadexcel.ExportListToExcelDashboard(list),
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            "BlocksReport.xlsx");
            }
            catch (Exception ex)
            {
                // Log the exception and return the view
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }

        public IActionResult DasboardCadre(string? StartDate, string? EndDate)
        {
            DashboardModel model = new DashboardModel()
            {
                StartDate = StartDate,
                EndDate = EndDate,
            };

            try
            {
                // Get the list of data
                var list = _dashboardworker.kaizenCountbasedonCadre(model)
                    .Select(item => new
                    {
                        cadreid = item.Cadreid,
                        cadrename = item.Cadrename,
                        TotalKaizensubmitted = item.TotalSubmittedKaizen
                    }).ToList();

                // Export to Excel and return the file
                return File(_downloadexcel.ExportListToExcelDashboard(list),
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            "CadreReport.xlsx");
            }
            catch (Exception ex)
            {
                // Log the exception and return the view
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }

        public IActionResult DasboardDomain(string? StartDate, string? EndDate)
        {
            DashboardModel model = new DashboardModel()
            {
                StartDate = StartDate,
                EndDate = EndDate,
            };

            try
            {
                // Get the list of data
                var list = _dashboardworker.kaizenCountbasedonDomain(model)
                    .Select(item => new
                    {
                        Domainid = item.Domainid,
                        Domainname = item.Domainname,
                        TotalKaizensubmitted = item.TotalSubmittedKaizen
                    }).ToList();

                // Export to Excel and return the file
                return File(_downloadexcel.ExportListToExcelDashboard(list),
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            "DomainReport.xlsx");
            }
            catch (Exception ex)
            {
                // Log the exception and return the view
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }
        public IActionResult DasboardDepartment(string? StartDate, string? EndDate)
        {
            DashboardModel model = new DashboardModel()
            {
                StartDate = StartDate,
                EndDate = EndDate,
            };

            try
            {
                // Get the list of data
                var list = _dashboardworker.kaizenCountbasedonBlocks(model)
                    .Select(item => new
                    {
                        Departmentid = item.Departmentid,
                        Departmentname = item.Departmentname,
                        TotalKaizensubmitted = item.TotalSubmittedKaizen
                    }).ToList();

                // Export to Excel and return the file
                return File(_downloadexcel.ExportListToExcelDashboard(list),
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            "DepartmentReport.xlsx");
            }
            catch (Exception ex)
            {
                // Log the exception and return the view
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }
    }
}
