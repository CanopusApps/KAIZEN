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
        public string DomainName { get; set; } = "";
        public bool Status { get; set; }
        public int TotalEmp { get; set; }

        public int User_count {  get; set; }

        public int KaizenSubmittedUser { get; set; }
        public int KaizenSubmitted {  get; set; }
        public int AllKaizenSubmitted {  get; set; }
        public string CreatedBy { get; set; } = "";

        public string ModifiedBy { get; set; } = "";
    }
}
