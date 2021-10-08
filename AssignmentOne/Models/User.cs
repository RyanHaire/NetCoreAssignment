using System.ComponentModel.DataAnnotations;
namespace AssignmentOne.Models
{
    public class User
    {
        [Required(ErrorMessage="Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Please enter your email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage="Please enter your phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", 
            ErrorMessage = "Phone Number should be in format 999-999-9999")]

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage="Please enter a password")]
        public string Password { get; set; }

        [Required(ErrorMessage="Please confirm your password")]
        public string ConfirmPassword{ get; set; }
    }
}