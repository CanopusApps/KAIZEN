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
        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}(?:\.[a-zA-Z]{2,})?$", ErrorMessage = "Invalid Email Address")]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(8, MinimumLength = 6, ErrorMessage = "Employee ID must be a minimum of 6 and maximum of 8 digits only")]
        public string EmpId { get; set; }

        [StringLength(16, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 16 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 16 characters")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        [StringLength(10)]
        public string Phoneno { get; set; }

        
        public string Gender { get; set; } = string.Empty;
  
        public int Did { get; set; } // stores domain id 

        
        public int DeptId { get; set; } // stores deptid 

        public int BlockId { get; set; } = 0;//stores BLockID
        public List<DomainModel> Domains { get; set; }
        public List<DepartmentModel> Departments { get; set; }

        public List<BlockModel> Blocks { get; set; }

    }

}
