using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.WinnersList
{   
    public class WinnersListModel 
    {
        public Guid Id { get; set; } 

        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string DomainName { get; set; }
        public string DepartmentName { get; set; }
      
        public Guid EmpGUID { get; set; }
        public string Category { get; set; } 
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string Status { get; set; }
    }
}
