using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.AdminModel
{
    public class UserGridModel
    {
        public string EmpID { get; set; } = "";
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";

        public string Gender { get; set; } = "";
        public string Domain { get; set; } = "";
        public string Department { get; set; } = "";
        public string UserType { get; set; } = "";
        public int ImageApprover { get; set; } = 0;
        public int Status { get; set; } = 0;

        public string PhoneNo { get; set; } = "";
        public string Password { get; set; } = "";
        public string Cadre { get; set; } = "";

    }
}
