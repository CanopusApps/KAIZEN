﻿using System.ComponentModel.DataAnnotations;

namespace Kaizen.Models.AdminModel
{
    public class EditUserModel
    {
        public string EmpID { get; set; }

        [Required(ErrorMessage = "First-name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string MiddleName { get; set; } = "";

        [Required(ErrorMessage = "Last-name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Phone Number")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Gender must be Male, Female, or Other")]
        public string Gender { get; set; } = string.Empty;

        public bool ImageApprover { get; set; } = false;

        public string ModifiedBy { get; set; }

        //cadre list
        public List<CadreModel> Cadre { get; set; }

        //Usertype list
        public List<UserTypeModel> UserType { get; set; }

        public List<DomainModel> Domains { get; set; }

        public List<DepartmentModel> Departments { get; set; }

        public List<BlockModel> Blocks { get; set; }
        //static list for status
        public List<StatusModel> Status { get; set; } = new List<StatusModel>
        {
            new StatusModel { StatusID = 1, StatusName = "Active" },
           new StatusModel { StatusID = 0, StatusName = "Inactive" }
        };
        [Required(ErrorMessage = "Block  is required")]
        public int BlockId { get; set; } = 0;//stores BLockID
        public int StatusName { get; set; } = 1;// Stores status (1 or 0)
        
        [Required(ErrorMessage = "Cadre is required")]
        public int Cid { get; set; } = 0;// stores cadre id
        [Required(ErrorMessage = "Usertype is required")]
        public int Rid { get; set; } = 0;// stores usertype id
        [Required(ErrorMessage = "Department  is required")]
        public int Did { get; set; } = 0;// stores domain id 
        [Required(ErrorMessage = "Sub-Department  is required")]
        public int DeptId { get; set; } = 0;// stores deptid 
    }

}
