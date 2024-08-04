using Kaizen.Models.AdminModel;
using Kaizen.Models.DashboardModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Data.DataServices.Interfaces
{
    public interface IDashboardRepository
    {
        public DataSet GetKaizenCount(DashboardModel model);
        public DataSet GetDomainKaizenCount(DashboardModel model);

        public DataSet GetDepartmentKaizenCount(DashboardModel model);


        public DataSet GetGraphKaizenCount(DashboardModel model);
        public DataSet GetOtherKaizenCount(DashboardModel model);


    }
}
