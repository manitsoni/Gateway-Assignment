using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace SourceControlFinalAssignment.Models
{
    public class UserRegistration
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Is Required")]
        [StringLength(10)]
        public string UserName { get; set; }
        [Required (ErrorMessage ="Email Is Required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password Is Required")]
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