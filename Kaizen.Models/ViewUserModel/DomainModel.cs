using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.ViewUserModel
{
    public class DomainModel
    {
        public int id { get; set; }
        public string DomainName { get; set; } = "";
        public bool StatusID { get; set; }
        public string flag { get; set; } = "";
        public int TotalEmp { get; set; }


    }
}
