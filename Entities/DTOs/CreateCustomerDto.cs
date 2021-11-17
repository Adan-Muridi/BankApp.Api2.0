using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CreateCustomerDto
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Gender is a required field.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Givenname is a required field.")]
        public string Givenname { get; set; }

        [Required(ErrorMessage = "Surname is a required field.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Streetaddress is a required field.")]
        public string Streetaddress { get; set; }

        [Required(ErrorMessage = "City is a required field.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Zipcode is a required field.")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Country is a required field.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "CountryCode is a required field.")]
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "Birthday is a required field.")]
        public DateTime? Birthday { get; set; }

        [Required(ErrorMessage = "Telephonecountrycode is a required field.")]
        public string Telephonecountrycode { get; set; }

        [Required(ErrorMessage = "Telephonenumber is a required field.")]
        public string Telephonenumber { get; set; }

        [Required(ErrorMessage = "Emailaddress is a required field.")]
        public string Emailaddress { get; set; }

        public string Password { get; set; }
        [Compare(nameof(Password),
            ErrorMessage = "The password and confirm password do not match")]
        public string ConfirmPassword { get; set; }

    }
}
