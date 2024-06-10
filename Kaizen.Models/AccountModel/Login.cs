using System.ComponentModel.DataAnnotations;

namespace Kaizen.Web.Models
{
    public class Login
    {
        public int ID { get; set; }
        public string? FullName { get; set; }
        public string? EmailID { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "User Name is Required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
        public string? RoleId { get; set; }
    }
}
