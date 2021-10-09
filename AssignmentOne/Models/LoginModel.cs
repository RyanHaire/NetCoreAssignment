using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AssignmentOne.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Please enter your email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage="Please enter a password")]
        public string Password { get; set; }
    }
}