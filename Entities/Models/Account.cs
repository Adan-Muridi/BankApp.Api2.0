using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Account
    {

        public int AccountId { get; set; }
        public string Frequency { get; set; }
        public DateTime Created { get; set; }
        public decimal Balance { get; set; }
        public int? AccountTypesId { get; set; }

        public AccountType AccountTypes { get; set; }
        public ICollection<Disposition> Dispositions { get; set; }
        public ICollection<Loan> Loans { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
