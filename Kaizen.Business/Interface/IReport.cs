using Kaizen.Models.ReportModel;
using System;
using System.Data;
using Kaizen.Models.DashboardModel;

namespace Kaizen.Business.Interface
{
    public interface IReport
    {
        public DataTable GetKaizenform(KaizenReportModel model);
        public DataTable GetBlockReport(KaizenReportModel model);
        public DataTable GetDomainReport(KaizenReportModel model);
        public DataTable GetDepartmentReport(KaizenReportModel model);
        public DataTable GetUsersReport(KaizenReportModel model);
        public DataTable GetUserLogform(KaizenReportModel model);
        public DataTable DashboardDepartmentReport(DashboardModel model);
        public DataTable DashboardDomainReport(DashboardModel model);
        public DataTable DashboardBlockReport(DashboardModel model);
        public DataTable DashboardCadreReport(DashboardModel model);
        public byte[] ExportDataTableToExcel(DataTable dataTable);
        public byte[] ExportListToExcelDashboard<T>(List<T> list);
        public int GetCount(object data);
    }
}
