using Kaizen.Models.AdminModel;
using Kaizen.Models.DashboardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Business.Interface
{
    public interface IDashboard
    {
        public List<TotalKaizennos> GetKaizentotalCount(DashboardModel model);
        public List<TotalKaizennos> GetKaizentotalCountmonth(DashboardModel model);
        public List<TotalKaizennos> GetKaizentotalCountCustomMonth(DashboardModel model);

        public  List<DomainModel> DomainbasedkaizenCount(DashboardModel model);
        public List<DepartmentModel> DepartmentbasedkaizenCount(DashboardModel model);

        public List<graphKaizentotalModel> kaizenCountbasedonDepartment(DashboardModel model);
        public List<graphKaizentotalModel> kaizenCountbasedonDomain(DashboardModel model);

         public List<graphKaizentotalModel> kaizenCountbasedonCadre(DashboardModel model);

        public List<graphKaizentotalModel> kaizenCountbasedonBlocks(DashboardModel model);

        public List<OtherDashboardmodel> Otherdashboard(DashboardModel model);

        public List<OtherDashboardmodel> OtherMonthbaseddashboard(DashboardModel model);

        public List<EmployeeDashboardModel> GetEmployeedashboardcount(DashboardModel model);
        public List<EmployeeDashboardModel> GetmonthbasedEmployeedashboardcount(DashboardModel model);

        public List<DomainModel> ManagerDomainbasedkaizenCount(DashboardModel model,string Empid);
        public List<DepartmentModel> managerDepartmentbasedkaizenCount(DashboardModel model,string Empid);




    }
}
