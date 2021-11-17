using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AddAccountDto
    {

        public int AccountId { get; set; }

        [Required(ErrorMessage = "Frequency is a required field.")]
        public string Frequency { get; set; }

        [Required(ErrorMessage = "Date is a required field.")]
        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Balance is a required field.")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage = "AccountTypesId is a required field.")]
        public int? AccountTypesId { get; set; }





        //public int AccountId { get; set; }
        //public string Frequency { get; set; }
        //public DateTime Created { get; set; }
        //public decimal Balance { get; set; }
        //public int? AccountTypesId { get; set; }

        //public AccountType AccountTypes { get; set; }
        //public ICollection<Disposition> Dispositions { get; set; }
        //public ICollection<Loan> Loans { get; set; }
        //public ICollection<Transaction> Transactions { get; set; }
    }
}
