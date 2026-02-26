using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HTMLCSSLecture.Models
{
    public class RegistrationModel
    {
        [Display(Name = "UserName")]
        public string Username { get; set; }
        

        [DisplayName("FirstName")]
        [StringLength(25, ErrorMessage ="Cannot exceed 25 characters")]
        public string FirstName { get; set; }
        

        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage ="Password Do Not Match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
