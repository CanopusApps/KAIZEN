using System.ComponentModel.DataAnnotations;

namespace Kaizen.Models.AdminModel
{
    public class ForgotPassword
    {
        [Required(ErrorMessage = "Employee ID is required")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "Employee ID must be between 6 and 8 digits long")]
        public int EmpID { get; set; }
    }
}
