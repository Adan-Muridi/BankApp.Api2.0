using Entities.DTOs;
using Entities.Models;
using Entities.Paging;
using Entities.RequestServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Api.Services
{
    public interface IBankService
    {
        public Customer CreateCustomer(CreateCustomerDto customer);
        //public Task<IEnumerable<Customer>> GetAllCustomer(RequestParameters requestParameters);
        Task<PagedList<Customer>> GetAllCustomers(bool trackChanges, RequestParameters requestParameters);
        public Account CreateAccount(AddAccountDto addAccountDto);
        public Account AddAccountForCustomer(AddAccountForCustomerDto addAccountForCustomerDto);
        public Task<Customer> GetCustomer(int id);
        public Task<Customer> GetCustomerByMail(string email);
        public void CreateDisposion(Disposition disposition);
        public void CreateDisposionCurrentCustomer(int id);
        public Task<Loan> AddLoan(AddLoanDto addLoanDto);
        public Task<Account> UserTransaction(TransferMoneyUserDto transferMoneyUserDto);
        public Task<Transaction> TransactionProcess(int accountId, decimal amount, decimal balance, string operation, string type);
        public Task<List<Transaction>> GetTransactions(int id);
    }
}
