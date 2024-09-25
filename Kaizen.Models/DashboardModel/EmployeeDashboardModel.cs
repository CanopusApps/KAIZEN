
namespace Kaizen.Models.DashboardModel
{
    public class EmployeeDashboardModel
    {
            public String EmpId { get; set; }
            public string MonthYear { get; set; }
            public string FirstName { get; set; }
            public int KaizenCount { get; set; }
            public int TotalApproved { get; set; }
            public int TotalRejected { get; set; }
            public int TotalPending { get; set; }
            public int ImageApproved { get; set; }
            public int ImageRejected { get; set; }
            public int ImagePending { get; set; }
            public int ManagerApproved { get; set; }
            public int ManagerRejected { get; set; }
            public int ManagerPending { get; set; }
            public int IEApproved { get; set; }
            public int IERejected { get; set; }
            public int IEPending { get; set; }
            public int FinanceApproved { get; set; }
            public int FinanceRejected { get; set; }
            public int FinancePending { get; set; }
        }
 }


