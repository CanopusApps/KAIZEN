using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.AdminModel
{
    public class DomainModel
    {
        public int Id { get; set; }
        public string? DomainName { get; set; } = string.Empty;
        public bool Status { get; set; }
        public int TotalEmp { get; set; }


    }
}
