using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.AdminModel
{
    public class LoginModel
    {
        public string UserName { get; set; }

        public int Password { get; set; }
        public string Email { get; set; }
        public int Empid { get; set; }
    }
}
