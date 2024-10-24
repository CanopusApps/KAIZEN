﻿using System.ComponentModel.DataAnnotations;

namespace Kaizen.Models.AdminModel
{
    public class ProfileModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength=1, ErrorMessage = "First Name can not contain more than 50 characters")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name can only contain letters")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Middle Name can not contain more than 50 characters")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Middle Name can only contain letters")]
        public string MiddleName { get; set; } = "";

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last Name can not contain more than 50 characters")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name can only contain letters")]
        public string LastName { get; set; }
        public string EmpID { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Gender must be Male, Female, or Other")]
        public string Gender { get; set; }

        public string Domain { get; set; }

        public string Department { get; set; }

        [Required(ErrorMessage = "Email is required")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        //[DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

    }
}
