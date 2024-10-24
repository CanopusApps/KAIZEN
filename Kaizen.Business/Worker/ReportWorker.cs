﻿using ClosedXML.Excel;
using Kaizen.Business.Interface;
using Kaizen.Data.DataServices.Interfaces;
using Kaizen.Models.DashboardModel;
using Kaizen.Models.ReportModel;
using System.Data;
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
        public DataTable GetBlockReport(KaizenReportModel model)
        {
            return _reportRepository.GetBlockReportData(model);
        }
        public DataTable GetDomainReport(KaizenReportModel model)
        {
            return _reportRepository.GetDomainReportData(model);
        }
        public DataTable GetDepartmentReport(KaizenReportModel model)
        {
            return _reportRepository.GetDepartmentReportData(model);
        }
        public DataTable GetUsersReport(KaizenReportModel model)
        {
            return _reportRepository.GetUsersReportData(model);
        }
        public DataTable GetUserLogform(KaizenReportModel model)
        {
            return _reportRepository.GetUserLogformData(model);
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
        public byte[] ExportListToExcelDashboard<T>(List<T> list)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");

                // Get the properties of the class
                var properties = typeof(T).GetProperties();

                // Add column headers
                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cell(1, i + 1).Value = properties[i].Name;
                }

                // Add rows with data
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j < properties.Length; j++)
                    {
                        var value = properties[j].GetValue(list[i], null);
                        worksheet.Cell(i + 2, j + 1).Value = value != null ? value.ToString() : string.Empty;
                    }
                }

                // Save to memory stream and return as byte array
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;
                    return stream.ToArray();
                }
            }
        }
        public int GetCount(object data)
        {
            return data switch
            {
                IEnumerable<KaizenReportModel> list => list.Count(),
                DataTable table => table.Rows.Count,
                _ => 0
            };
        }
        public DataTable DashboardDepartmentReport(DashboardModel model)
        {
            DataSet ds = _reportRepository.GetDashboardData(model);
            return ds.Tables[0];
        }
        public DataTable DashboardDomainReport(DashboardModel model)
        {
            DataSet ds = _reportRepository.GetDashboardData(model);
            return ds.Tables[1];
        }
        public DataTable DashboardBlockReport(DashboardModel model)
        {
            DataSet ds = _reportRepository.GetDashboardData(model);
            return ds.Tables[2];
        }
        public DataTable DashboardCadreReport(DashboardModel model)
        {
            DataSet ds = _reportRepository.GetDashboardData(model);
            return ds.Tables[3];
        }
    }
}
