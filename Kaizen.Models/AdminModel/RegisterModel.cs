using System.ComponentModel.DataAnnotations;

namespace Kaizen.Models.AdminModel
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "First-name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last-name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}(?:\.[a-zA-Z]{2,})?$", ErrorMessage = "Invalid Email Address")]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Employee ID is required")]
        //[RegularExpression(@"^\d{1,6}$", ErrorMessage = "Employee ID must be a number with 6 digits only")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "Employee ID must be a minimum of 6 and maximum of 8 digits only")]
        public string EmpId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 16 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 16 characters")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Phone Number")]
        public string Phoneno { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Gender must be Male, Female, or Other")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department  is required")]
        public int Did { get; set; } // stores domain id 

        [Required(ErrorMessage = "Sub-Department is Required")]
        public int DeptId { get; set; } // stores deptid 

        [Required(ErrorMessage = "Block  is required")]
        public int BlockId { get; set; } = 0;//stores BLockID
        [Required(ErrorMessage = "Cadre is required")]
        public int Cid { get; set; } = 0;// stores cadre id
        public List<DomainModel> Domains { get; set; }
        public List<DepartmentModel> Departments { get; set; }
        public List<BlockModel> Blocks { get; set; }
        public List<CadreModel> Cadre { get; set; }

    }

}
