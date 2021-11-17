using Contracts;
using Entities.Context;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LoanRepository :RepositoryBase<Loan>, ILoanRepository
    {
        public LoanRepository(BankDbContext bankDbContext) :base(bankDbContext)
        {

        }

        public void CreateLoan(Loan loan)
        {
            Create(loan);
            
        }
    }
}

