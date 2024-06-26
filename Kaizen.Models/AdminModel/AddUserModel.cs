﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Kaizen.Models.AdminModel
{
    public class AddUserModel
    {
        [Required(ErrorMessage = "Employee ID is required")]
        [RegularExpression(@"^\d{1,6}$", ErrorMessage = "Employee ID must be a number with 6 digits only")]
        public string EmpId { get; set; }

        [Required(ErrorMessage = "First-name is required")]
        [StringLength(10, ErrorMessage = "Name cannot be longer than 50 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string MiddleName { get; set; } = "";

        [Required(ErrorMessage = "Last-name is required")]
        [StringLength(10, ErrorMessage = "Name cannot be longer than 50 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string LastName { get; set; }
		[Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Phone Number")]
        public string Phoneno { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]

        public string CreatedbyId { get; set; } = "";
        public string Email { get; set; }
       
        [Required(ErrorMessage = "Password is required")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 10 characters")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Gender must be Male, Female, or Other")]
        public string Gender { get; set; } = string.Empty;

        //cadre list
        
        public List<CadreModel> Cadre { get; set; }
        //Usertype list
        
        public List<UserTypeModel> UserType { get; set; }
        // Domain List
        public List<DomainModel> Domains { get; set; }
		public List<DepartmentModel> Departments { get; set; }
      
        // static list for status
        public List<StatusModel> Status { get; set; } = new List<StatusModel>//
        {
            new StatusModel  { StatusID = 1, StatusName = "Active" },
           new StatusModel { StatusID = 0, StatusName = "Inactive" }
        };
        public int statusname { get; set; }// Stores status (1 or 0)

        [Required(ErrorMessage = "Cadre is required")]
        public int Cid { get; set; } = 0;// stores cadre id
        [Required(ErrorMessage = "Usertype is required")]
        public int Rid { get; set; } = 0;// stores usertype id
        [Required(ErrorMessage = "Domain  is required")]
        public int Did { get; set; } = 0;// stores domain id 
        public int DeptId { get; set; } = 0;// stores deptid 
    }
}