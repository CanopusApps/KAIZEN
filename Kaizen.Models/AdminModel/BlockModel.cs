using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.AdminModel
{
    public class BlockModel
    {
        public int Id { get; set; }
        public string BlockName { get; set; } = "";
        public bool Status{ get; set; }

        public string CreatedBy { get; set; } = "";
        public string ModifiedBy { get; set; } = "";

    }
}
