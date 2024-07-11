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
        [RegularExpression(@"^\d{1,6}$", ErrorMessage = "Employee ID must be a number with 6 digits only")]
        public string EmpId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 10 characters")]
        public string Password { get; set; }

        
    }

    
}
