using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaizen.Models.AdminModel;



namespace Kaizen.Models.AdminModel
{
    public class ProfileModel
    {
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "FirstName can not contain more than 50 characters")]
        [RegularExpression("@^[a-zA-Z]+$", ErrorMessage = "FirstName can only contain letters")]
        public string FirstName { get; set; }


        [StringLength(50, MinimumLength = 0, ErrorMessage = "MiddleName can not contain more than 50 characters")]
        [RegularExpression("@^[a-zA-Z]*$", ErrorMessage = "MiddleName can only contain letters")]
        public string MiddleName { get; set; } = "";

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "LastName can not contain more than 50 characters")]
        [RegularExpression("@^[a-zA-Z]+$", ErrorMessage = "LastName can only contain letters")]
        public string LastName { get; set; }

        public string EmpID { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("@^(Male|Female|Other)$", ErrorMessage = "Gender must be Male, Female, or Other")]
        public string Gender { get; set; }

        public string Domain { get; set; }

        public string Department { get; set; }

        //[Required(ErrorMessage = "Email is required")]
        //[RegularExpression("@ ^[\\w\\.-]+@[a-zA-Z\\d\\.-]+\\.[a-zA-Z]{2,}$ ", ErrorMessage = "Email entered is InValid!!")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        //[EmailAddress]
        //[Required]
        //[RegularExpression("/^([a-zA-Z0-9_\\.\\-\\+])+@\\(([a - zA - Z0 - 9\\-]) +\\.)+([a-zA-Z0-9]{2,4})+$/")]
        ////[DataType(DataType.EmailAddress)]
        
        //public string Email { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        //[DataType(DataType.EmailAddress)]
        //[RegularExpression(/^([a - zA - Z0 - 9_\.\-\+])+@@(([a - zA - Z0 - 9\-]) +\.)+([a - zA - Z0 - 9]{2,4})+$/)]
        public string Email { get; set; }

    }
}
