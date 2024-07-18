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

        public ReportsController(IReport reportworker, ILogger<ReportsController> logger)
        {
            _downloadexcel = reportworker;
        }

        public IActionResult ReportDownload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KaizenForm(KaizenReportModel model)
        {
            try
            {
                DataTable dt = _downloadexcel.GetKaizenform(model);

                byte[] fileContents = ExportDataTableToExcel(dt, "KaizenReport.xlsx");
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ExcelReports");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var filePath = Path.Combine(folderPath, "KaizenReport.xlsx");
                await System.IO.File.WriteAllBytesAsync(filePath, fileContents);
                return Json(new { success = true, fileName = "ExcelReports/KaizenReport.xlsx" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error generating report.");
            }
        }
        private byte[] ExportDataTableToExcel(DataTable dataTable, string fileName)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dataTable.Columns[i].ColumnName;
                }
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dataTable.Rows[i][j].ToString();
                    }
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> DownloadExcel(string file)
        {
            try
            {
                var fileName = file;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound();
                }
                byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Path.GetFileName(filePath));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error downloading file.");
            }
        }
    }
}
