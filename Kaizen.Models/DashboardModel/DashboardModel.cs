using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.DashboardModel
{
    public class DashboardModel
    {
        public string StartDate { get; set; } = "";
        public string EndDate { get; set; } = "";
        public string Domain { get; set; } = "";
        public string Department { get; set; } = "";

        public string Cadre { get; set; } = "";

        public string Block { get; set; } = "";
        public List<CadreModel> CadreList { get; set; }
        public List<BlockModel> blockList {  get; set; }
        public List<DomainModel> DomainList { get; set; }
        public List<TotalKaizennos> TotalKaizenList {  get; set; }

        public List<DomainModel> DomainmanagerList { get; set; }
        public List<DepartmentModel> departmentmangerlist { get; set; }
        public List<CountKaizenStatus> CountKaizenList { get; set; }

        public List<TotalKaizennos> MonthTotalKaizenList { get; set; }
        public List<TotalKaizennos> CustomMonthTotalKaizenList { get; set; }

        public List<CountKaizenStatus> MonthCountKaizenList { get; set; }

        public List<graphKaizentotalModel> domainbasedgraph {  get; set; }
        public List<graphKaizentotalModel> departmentbasedgraph { get; set; }
        public List<graphKaizentotalModel> blockbasedgraph { get; set; }
        public List<graphKaizentotalModel> Cadrebasedgraph { get; set; }

        public List<OtherDashboardmodel> OtherdashboardList { get; set; }
        public List<OtherDashboardmodel> MonthBasedOtherdashboardList { get; set; }

        public List<EmployeeDashboardModel> EmployeedashboardList { get; set; }
        public List<EmployeeDashboardModel> MonthBasedEmployeedashboardList { get; set; }



    }

    public class TotalKaizennos
    {
        public string monthbasedTotal {  get; set; }
        public int TotalKaizens { get; set; }
        public int DRITotal { get; set; }
        public int FinanceTotal { get; set; }
        public int IETotal { get; set; }
        public int Imagetotal {  get; set; }

        public int TotalApproved { get; set; }

        public int TotalPending { get; set; }
        public int TotalRejected { get; set; }
    }
    public class CountKaizenStatus
    {
        public string monthbased { get; set; }
        public int ApprovalCount { get; set; }

        public int ApprovalStatus { get; set; }

        public  string ApprovalStatusdesc { get; set; }

    }

   

}
