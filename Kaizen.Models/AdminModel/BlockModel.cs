using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.AdminModel
{
    public class BlockModel
    {
        public int Id { get; set; } = 0;
        public string BlockName { get; set; } = "";
        public int User_count { get; set; }
        public int TotalEmp { get; set; }
        public bool Status{ get; set; }
        public string CreatedBy { get; set; } = "";
        public string ModifiedBy { get; set; }

    }
}
