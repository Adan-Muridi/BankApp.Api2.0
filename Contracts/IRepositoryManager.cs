using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICustomerRepository Customer { get; }
        IDispositionRepository Disposition { get; }
        IAccountRepository Account { get; }
        ILoanRepository Loan { get;}
        ITransactionsRepository Transactions { get; }
        //Task SaveAsync();
        void saveChanges();


    }
}
