using Contracts;
using Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private ICustomerRepository _customerRepository;
        private IDispositionRepository _dispositionRepository;
        private IAccountRepository _accountRepository;
        private ILoanRepository _loanRepository;
        private ITransactionsRepository _transactionsRepository;
        private BankDbContext _bankDbContext;


        public RepositoryManager(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new CustomerRepository(_bankDbContext);
                return _customerRepository;
            }
        }

        public IDispositionRepository Disposition
        {
            get
            {
                if (_dispositionRepository == null)
                    _dispositionRepository = new DispositionRepository(_bankDbContext);
                return _dispositionRepository;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_accountRepository == null)
                    _accountRepository = new AccountRepository(_bankDbContext);
                return _accountRepository;
            }

        }
         public ITransactionsRepository Transactions
        {
            get
            {
                if (_transactionsRepository == null)
                    _transactionsRepository = new TransactionsRepository(_bankDbContext);
                return _transactionsRepository;
            }

        }
        public ILoanRepository Loan
        {
            get
            {
                if (_loanRepository == null)
                    _loanRepository = new LoanRepository(_bankDbContext);
                return _loanRepository;
            }

        }

        public void saveChanges() => _bankDbContext.SaveChanges();
    }
}
