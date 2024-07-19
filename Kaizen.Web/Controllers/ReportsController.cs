using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Kaizen.Business.Interface;
using Kaizen.Models.ReportModel;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace Kaizen.Web.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReport _downloadexcel;

        public ReportsController(IReport reportworker)
        {
            _downloadexcel = reportworker;
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
                return StatusCode(500);
            }
        }
    }
}
