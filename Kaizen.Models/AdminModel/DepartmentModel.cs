using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.AdminModel
{
    public class DepartmentModel
    {
        public int DeptId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public List<DepartmentModel> DepartmentList { get; set; }
        public string DomainName { get; set; } = string.Empty;
        public List<DomainModel> DomainList { get; set; }
        public int DomainId { get; set; }

        public bool Status { get; set; }

    }
}
