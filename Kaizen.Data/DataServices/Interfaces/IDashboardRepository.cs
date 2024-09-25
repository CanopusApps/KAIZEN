using Kaizen.Models.DashboardModel;
using System.Data;

namespace Kaizen.Data.DataServices.Interfaces
{
    public interface IDashboardRepository
    {
        public DataSet GetKaizenCount(DashboardModel model);
        public DataSet GetDomainKaizenCount(DashboardModel model);
        public DataSet GetDepartmentGraphKaizenCount(DashboardModel model);
        public DataSet GetDepartmentKaizenCount(DashboardModel model);
        public DataSet Getmanagetdomaindepartment(DashboardModel model, string Empid);
        public DataSet GetGraphKaizenCount(DashboardModel model);
        public DataSet GetOtherKaizenCount(DashboardModel model);
        public DataSet GetEmployeeDashboardCount(DashboardModel model);
    }
}
