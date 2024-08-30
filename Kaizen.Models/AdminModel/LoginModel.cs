using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.AdminModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Employee ID is required")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "Employee ID must be between 6 and 8 digits long")]
        public string EmpId { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 10 characters")]
        public string Password { get; set; }
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 10 characters")]
        public string ConfirmPassword { get; set; }

        
    }

    
}
