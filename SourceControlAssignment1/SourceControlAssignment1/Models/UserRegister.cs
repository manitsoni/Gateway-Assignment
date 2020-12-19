using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace SourceControlAssignment1.Models
{
    public class UserRegister
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        [StringLength(10)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Id Is Required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Age Is Required")]
        [Range(18, 65, ErrorMessage = "Age must be between 18 to 65")]
        public int Age { get; set; }


        [Required(ErrorMessage = "Contact Number Is Required")]
        [Display(Name = "Phone")]
        [RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{4})[-. ]?([0-9]{3})$", ErrorMessage = "Please Correct Format")]
        public int ContactNo { get; set; }

        [DataType(DataType.CreditCard)]
        [Display(Name = "Credit Card")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [MembershipPassword(
        MinRequiredNonAlphanumericCharacters = 1,
        MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
        ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc)."
        )]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}