using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Entity.Account
{
    public class LoginEntity
    {
        public int ID { get; set; }
        public string? FullName { get; set; }
        public string? EmailID { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? RoleId { get; set; }

    }
}
