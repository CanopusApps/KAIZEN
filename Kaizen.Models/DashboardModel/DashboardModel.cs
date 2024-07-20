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
        public List<DomainModel> DomainList { get; set; }
        public List<TotalKaizennos> TotalKaizenList {  get; set; }

        public List<CountKaizenStatus> CountKaizenList { get; set; }

    }

    public class TotalKaizennos
    {
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
        public int ApprovalCount { get; set; }

        public int ApprovalStatus { get; set; }

        public  string ApprovalStatusdesc { get; set; }

    }
}
