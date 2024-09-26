using Kaizen.Models.DashboardModel;
using Kaizen.Models.ReportModel;
using System.Data;

namespace Kaizen.Data.DataServices.Interfaces
{
    public interface IReportRepository
    {
        public DataTable GetKaizenformData(KaizenReportModel model);
        public DataTable GetBlockReportData(KaizenReportModel model);
        public DataTable GetDomainReportData(KaizenReportModel model);
        public DataTable GetDepartmentReportData(KaizenReportModel model);
        public DataTable GetUsersReportData(KaizenReportModel model);
        public DataTable GetUserLogformData(KaizenReportModel model);
        public DataSet GetDashboardData(DashboardModel model);
    }
}
