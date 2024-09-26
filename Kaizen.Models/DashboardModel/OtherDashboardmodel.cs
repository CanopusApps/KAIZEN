
namespace Kaizen.Models.DashboardModel
{
    public class OtherDashboardmodel
    {
        public string MonthYear { get; set; }
        public string EmpId { get; set; }
        public int Usertypeid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Usertypedesc { get; set; }
        // Total counts
        public int ImageTotal { get; set; }
        public int ManagerTotal { get; set; }
        public int IETotal { get; set; }
        public int FinanceTotal { get; set; }
        // Separate counts for Image Approver
        public int ImageApproved { get; set; }
        public int ImageRejected { get; set; }
        public int ImagePending { get; set; }

        // Separate counts for Manager
        public int ManagerApproved { get; set; }
        public int ManagerRejected { get; set; }
        public int ManagerPending { get; set; }

        // Separate counts for IE
        public int IEApproved { get; set; }
        public int IERejected { get; set; }
        public int IEPending { get; set; }

        // Separate counts for Finance
        public int FinanceApproved { get; set; }
        public int FinanceRejected { get; set; }
        public int FinancePending { get; set; }

        public int dricreatedkaizen { get; set; }
    }
}
