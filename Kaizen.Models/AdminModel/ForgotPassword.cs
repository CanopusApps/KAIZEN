using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.AdminModel
{
    public class ForgotPassword
    {
        [Required(ErrorMessage = "Employee ID is required")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "Employee ID must be between 6 and 8 digits long")]
        public int EmpID { get; set; }
    }
}
