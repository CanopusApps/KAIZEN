using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.AdminModel
{
    public class RegisterModel
    {
        
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

       
        public string EmpId { get; set; }

       
        public string Password { get; set; }
        public string Phoneno { get; set; }

        
        public string Gender { get; set; } = string.Empty;
  
        public int Did { get; set; } // stores domain id 

        
        public int DeptId { get; set; } // stores deptid 

        public List<DomainModel> Domains { get; set; }
        public List<DepartmentModel> Departments { get; set; }

    }

}
