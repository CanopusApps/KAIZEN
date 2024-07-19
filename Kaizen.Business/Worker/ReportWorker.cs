using ClosedXML.Excel;
using Kaizen.Business.Interface;
using Kaizen.Data.DataServices;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.AdminModel;
using Kaizen.Models.ReportModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Worker
{
    public class ReportWorker : IReport
    {
        private readonly IReportRepository _reportRepository;

        public ReportWorker(IReportRepository repositoryReportdata)
        {
            this._reportRepository = repositoryReportdata;
        }

        public DataTable GetKaizenform(KaizenReportModel model)
        {
            return _reportRepository.GetKaizenformData(model);
        }

        public byte[] ExportDataTableToExcel(DataTable dataTable)
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
                    stream.Position = 0;
                    return stream.ToArray();
                }
            }
        }
    }
}
