using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        public string Gender { get; set; }

        public string Givenname { get; set; }

        public string Surname { get; set; }

        public string Streetaddress { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public string Country { get; set; }

        public string CountryCode { get; set; }

        public DateTime? Birthday { get; set; }

        public string Telephonecountrycode { get; set; }

        public string Telephonenumber { get; set; }

        public string Emailaddress { get; set; }

        public ICollection<Disposition> Dispositions { get; set; }
    }
}
