﻿using Kaizen.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Models.AdminModel
{
    public class EditUserModel
    {
        public string EmpID { get; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Phone Number")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 10 characters")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The Password and Confirmation Password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Gender must be Male, Female, or Other")]
        public string Gender { get; set; } = string.Empty;

        public bool ImageApprover { get; set; } = false;

        //cadre list
        public List<CadreModel> Cadre { get; set; }

        //Usertype list
        public List<UserTypeModel> UserType { get; set; }

        public List<DomainModel> Domains { get; set; }

        public List<DepartmentModel> Departments { get; set; }


        //static list for status
        public List<StatusModel> StatusName { get; set; } = new List<StatusModel>
        {
            new StatusModel { StatusID = 1, StatusName = "Active" },
           new StatusModel { StatusID = 0, StatusName = "Inactive" }
        };

        //stores status 0 or 1
        public int StatusState { get; set; }

        //stores cadre ID
        public int Cid { get; set; } = 0;

        //stores Role ID for Usertype
        public int Rid { get; set; } = 0;

        //stores domain ID
        public int Did { get; set; } = 0;

        //stores department ID
        public int Deptid { get; set; } = 0;
    }

}
