using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Kaizen.Business.Interface;
using Kaizen.Models.ReportModel;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using NPOI.POIFS.Storage;
using Kaizen.Data.Constant;

namespace Kaizen.Web.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReport _downloadexcel;

        public ReportsController(IReport reportworker)
        {
            _downloadexcel = reportworker;
        }

        public IActionResult ReportDownload(KaizenReportModel model)
        {
            try
            {
                var kaizenList = _downloadexcel.GetKaizenform(model);
                var blockList = _downloadexcel.GetBlockReport(model);
                var domainList = _downloadexcel.GetDomainReport(model);
                var departmentList = _downloadexcel.GetDepartmentReport(model);

                // ViewBag counts
                ViewBag.KaizenCount = _downloadexcel.GetCount(kaizenList);
                ViewBag.BlockCount = _downloadexcel.GetCount(blockList);
                ViewBag.DomainCount = _downloadexcel.GetCount(domainList);
                ViewBag.DepartmentCount = _downloadexcel.GetCount(departmentList);

                return View();
            }
            catch (Exception ex)
            {
                LogEvents.LogToFile(DbFiles.Title, ex.ToString());
                return View();
            }
        }
        //private int GetCount(object data)
        //{
        //    return data switch
        //    {
        //        IEnumerable<KaizenReportModel> list => list.Count(),
        //        DataTable table => table.Rows.Count,
        //        _ => 0
        //    };
        //}

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
    }
}
