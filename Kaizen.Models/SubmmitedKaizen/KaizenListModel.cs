using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.AdminModel
{
    public class KaizenListModel
    {
        public string KaizenTheme { get; set; }="";
        public string TeamName { get; set; }="";

        public string Block { get; set; } = "";
        public string HorozantalDeployment { get; set; } = "";
        public string IEApprovedDept { get; set; } = "";
        public string FinnanceDeptAppr { get; set; } = "";
        public string Shortlisted { get; set; } = "";
        public string ApprovalStatus { get; set; } = "";
        public string CreatedBy { get; set; } = "";
        public string CreatedDate { get; set; } = "";

        public string StartDate { get; set; } = "";
        public string EndDate { get; set; } = "";
        public string Domain { get; set; } = "";
        public string Department { get; set; } = "";
        public string Status { get; set; } = "";
    }
}
