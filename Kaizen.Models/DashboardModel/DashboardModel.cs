using Kaizen.Models.AdminModel;

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
        public List<TotalKaizennos> MonthTotalKaizenList { get; set; }
        public List<TotalKaizennos> CustomMonthTotalKaizenList { get; set; }
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
        public int CardImageApproved {  get; set; }
        public int CardImagePending { get; set; }
        public int CardImageRejected { get; set; }
        public int CardManagerApproved { get; set; }
        public int CardManagerPending { get; set; }
        public int CardManagerRejected { get; set; }
        public int CardIEApproved {  get; set; }
        public int CardIEPending { get; set; }
        public int CardIERejected { get; set; }
        public int CardFinanceApproved { get; set; }
        public int CardFinancePending { get; set; }
        public int CardFinanceRejected { get; set; }
    }
}
