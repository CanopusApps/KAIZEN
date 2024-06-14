using System;
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

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Phone Number")]
        public string Phoneno { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
       
        [Required(ErrorMessage = "Password is required")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 10 characters")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Gender must be Male, Female, or Other")]
        public string Gender { get; set; } = "";

        //cadre list
        public List<DropDownEntity>? cadre { get; set; }

        //Usertype list
        public List<RoleDropDown>? UserType { get; set; }

        // Domain List
        public List<DomainDropDown>? Domain { get; set; }
       
        
        // static list for status
        public List<StatusDropDown> Status { get; set; } = new List<StatusDropDown>//
        {
            new StatusDropDown { DataValueField = 1, DataTextField = "Active" },
           new StatusDropDown { DataValueField = 0, DataTextField = "Inactive" }
        };




        public int statusname { get; set; }// Stores status (1 or 0)
        public int Cid { get; set; } = 0;// stores cadre id
        public int Rid { get; set; } = 0;// stores usertype id
        public int Did { get; set; } = 0;// stores domain id 

        public int DeptId { get; set; } = 0;// stores deptid


      
    }
    // class to store Usertype table data into a list
    public class RoleDropDown
    {
        public virtual int? DataValueField { get; set; }
        public virtual string? DataTextField { get; set; }

        public virtual string DataCodeField { get; set; }
        public virtual string DataAltValueField { get; set; }
    }
    //class to store cadre table data into a list
    public class DropDownEntity
    {
        public virtual int? DataValueField { get; set; }
        public virtual string? DataTextField { get; set; }

        public virtual string DataCodeField { get; set; }
        public virtual string DataAltValueField { get; set; }

    }
    // class to store Status table data into a list
    public class StatusDropDown
    {
        public int DataValueField { get; set; }
        public string DataTextField { get; set; }
    }
    // class to store domain table data into a list
    public class DomainDropDown
    {
        public virtual int? DataValueField { get; set; }
        public virtual string? DataTextField { get; set; }

        public virtual string DataCodeField { get; set; }
        public virtual string DataAltValueField { get; set; }
    }
    // department class to store dept list
    //public class DepartmentModel
    //{
    //    public int DeptId { get; set; } =0;
    //    public string DepartmentName { get; set; } = "";
    //    public string flag { get; set; } = "";

    //}
}

