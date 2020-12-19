using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControlFinalAssignment.Models
{
    public class AddUser
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Firstname must be required!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Middlename must be required!")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage ="Lastname must be required!")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email must be required!")]
        public string Email { get; set; }

      
       
        public HttpPostedFileBase ImageFile { get; set; }
        public string ProductImage { get; set; }

        [DataType(DataType.CreditCard)]
        [Required(ErrorMessage ="Creditcard number must be required")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage ="Addressline1 must be required!")]
        public string AdressLine1 { get; set; }

        [Required(ErrorMessage = "Addressline1 must be required!")]
        public string AdresLine2 { get; set; }

        [Required(ErrorMessage = "Addressline2 must be required!")]
        public int Pincode { get; set; }

        [Required(ErrorMessage = "City must be required!")]
        public string City { get; set; }

        [Required(ErrorMessage = "State must be required!")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country must be required!")]
        public string Country { get; set; }

    }
}