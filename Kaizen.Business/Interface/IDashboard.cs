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
        public List<CountKaizenStatus> GetKaizenCount(DashboardModel model);
        public List<TotalKaizennos> GetKaizentotalCount(DashboardModel model);

        public List<CountKaizenStatus> GetKaizenCountmonth(DashboardModel model);
        public List<TotalKaizennos> GetKaizentotalCountmonth(DashboardModel model);
        public List<TotalKaizennos> GetKaizentotalCountCustomMonth(DashboardModel model);

        public  List<DomainModel> DomainbasedkaizenCount(DashboardModel model);
        public List<DepartmentModel> DepartmentbasedkaizenCount(DashboardModel model);
    }
}
