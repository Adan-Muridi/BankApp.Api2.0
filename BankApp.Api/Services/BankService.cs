using AutoMapper;
using Contracts;
using Entities.DTOs;
using Entities.Models;
using Entities.Paging;
using Entities.RequestServices;
//using Entities.SearchRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Api.Services
{
    public class BankService : IBankService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private IFacade _facad;

        public BankService(IRepositoryManager repositoryManager, IMapper mapper, IFacade facad)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _facad = facad;
        }

        public Account CreateAccount(AddAccountDto addAccountDto)
        {

            var mappedAccount = _mapper.Map<Account>(addAccountDto);
            _repositoryManager.Account.CreateAccount(mappedAccount);
            _repositoryManager.saveChanges();
            var accountToReturn = _mapper.Map<Account>(mappedAccount);
            return accountToReturn;
        }

        public Account AddAccountForCustomer(AddAccountForCustomerDto addAccountForCustomerDto)
        {

            var mappedAccount = _mapper.Map<Account>(addAccountForCustomerDto);
            _repositoryManager.Account.CreateAccount(mappedAccount);
            _repositoryManager.saveChanges();
            var accountToReturn = _mapper.Map<Account>(mappedAccount);
            return accountToReturn;
        }


        public Customer CreateCustomer(CreateCustomerDto customer)
        {
            var mappedCustomer = _mapper.Map<Customer>(customer);
            _repositoryManager.Customer.CreateCustomer(mappedCustomer);
            _repositoryManager.saveChanges();
            var customertoReturn = _mapper.Map<Customer>(mappedCustomer);
            return customertoReturn;
        }

        public void CreateDisposion(Disposition disposition)
        {
            _repositoryManager.Disposition.CreateDisposion(disposition);
            _repositoryManager.saveChanges();
        }

        public void CreateDisposionCurrentCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllCustomer(RequestParameters requestParameters)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomer(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<Loan> AddLoan(AddLoanDto addLoanDto)
        {
            var mappedLoan = _mapper.Map<Loan>(addLoanDto);
            _repositoryManager.Loan.CreateLoan(mappedLoan);
            _repositoryManager.saveChanges();



            Transaction transaction = new Transaction()
            {
                AccountId = addLoanDto.AccountId,
                Amount = addLoanDto.Amount,
                Date = DateTime.Now,
                Type = "Credit"
                // Balance = addLoanDto.Amount
            };
            _repositoryManager.Transactions.CreateTransaction(transaction);

            _repositoryManager.saveChanges();

            Account accounReturned = await _repositoryManager.Account.GetAccount(addLoanDto.AccountId, trackChanges: true);

            decimal NewBalance = accounReturned.Balance + addLoanDto.Amount;

            accounReturned.Balance = NewBalance;
            var xxxxxxx = accounReturned;

            _repositoryManager.Account.UpdateAccout(accounReturned);

            _repositoryManager.saveChanges();


            return mappedLoan;
        }

        public Task<PagedList<Customer>> GetAllCustomers(bool trackChanges, RequestParameters requestParameters)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetCustomerByMail(string email)
        {
            return await _repositoryManager.Customer.GetCustomerByMail(email, trackChanges: false);
        }

        public async Task<Account> UserTransaction(TransferMoneyUserDto transferMoneyUserDto)
        {

            Account destinatinAccount = await _repositoryManager.Account.GetAccount(transferMoneyUserDto.AccountDestinationId, trackChanges: true);
            decimal newIncreasedBalance = destinatinAccount.Balance + transferMoneyUserDto.Amount;
            destinatinAccount.Balance = newIncreasedBalance;

            Account OriginalAccountOfTransference = await _repositoryManager.Account.GetAccount(transferMoneyUserDto.AccountOriginId, trackChanges: true);
            decimal NewReducedBalance = OriginalAccountOfTransference.Balance - transferMoneyUserDto.Amount;
            OriginalAccountOfTransference.Balance = NewReducedBalance;
            _repositoryManager.Account.UpdateAccout(destinatinAccount);
            _repositoryManager.Account.UpdateAccout(OriginalAccountOfTransference);

            _repositoryManager.saveChanges();
            await TransactionProcess(destinatinAccount.AccountId, transferMoneyUserDto.Amount, destinatinAccount.Balance, transferMoneyUserDto.Operation, "Debit");
            await TransactionProcess(OriginalAccountOfTransference.AccountId, transferMoneyUserDto.Amount, OriginalAccountOfTransference.Balance, transferMoneyUserDto.Operation, "Debit");

            return OriginalAccountOfTransference;
        }

        public async Task<Transaction> TransactionProcess(int accountId, decimal amount, decimal balance, string operation, string type)
        {
            Transaction transaction = new Transaction
            {
                AccountId = accountId,
                Amount = amount,
                Date = DateTime.Now,
                Symbol = "KR",
                Type = type,
                Operation = operation,
                Balance = balance,

            };


            _repositoryManager.Transactions.CreateTransaction(transaction);
            _repositoryManager.saveChanges();

            return transaction;
        }

        public Task<List<Transaction>> GetTransactions(int id)
        {
            return _repositoryManager.Transactions.GetTransactions(id);
        }






















        //private readonly IRepositoryManager _repositoryManager;
        //private readonly IMapper _mapper;
        //private IFacade _facad;

        //public BankService(IRepositoryManager repositoryManager, IMapper mapper, IFacade facad)
        //{
        //    _repositoryManager = repositoryManager;
        //    _mapper = mapper;
        //    _facad = facad;
        //}

        //public Account CreateAccount(AddAccountDto addAccountDto)
        //{

        //    var mappedAccount = _mapper.Map<Account>(addAccountDto);
        //    _repositoryManager.Account.CreateAccount(mappedAccount);
        //    _repositoryManager.saveChanges();
        //    var accountToReturn = _mapper.Map<Account>(mappedAccount);
        //    return accountToReturn;
        //}

        //public Account AddAccountForCustomer (AddAccountForCustomerDto addAccountForCustomerDto)
        //{

        //   var mappedAccount = _mapper.Map<Account>(addAccountForCustomerDto);
        //    _repositoryManager.Account.CreateAccount(mappedAccount);
        //    _repositoryManager.saveChanges();
        //    var accountToReturn = _mapper.Map<Account>(mappedAccount);
        //    return accountToReturn;
        //}


        //public Customer CreateCustomer(CreateCustomerDto customer)
        //{
        //    var mappedCustomer = _mapper.Map<Customer>(customer);
        //    _repositoryManager.Customer.CreateCustomer(mappedCustomer);
        //    _repositoryManager.saveChanges();
        //    var customertoReturn = _mapper.Map<Customer>(mappedCustomer);
        //    return customertoReturn;
        //}

        //public void CreateDisposion(Disposition disposition)
        //{
        //    _repositoryManager.Disposition.CreateDisposion(disposition);
        //    _repositoryManager.saveChanges();
        //}

        //public void CreateDisposionCurrentCustomer(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Customer>> GetAllCustomer(RequestParameters requestParameters)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Customer> GetCustomer(int id)
        //{
        //    throw new NotImplementedException();
        //}



        //public async Task<Loan> AddLoan(AddLoanDto addLoanDto)
        //{
        //    var mappedLoan = _mapper.Map<Loan>(addLoanDto);
        //     _repositoryManager.Loan.CreateLoan(mappedLoan);
        //    _repositoryManager.saveChanges();



        //    Transaction transaction = new Transaction()
        //    {
        //        AccountId = addLoanDto.AccountId,
        //        Amount = addLoanDto.Amount,
        //        Date = DateTime.Now,
        //        Type = "Credit"
        //        // Balance = addLoanDto.Amount
        //    };
        //    _repositoryManager.Transactions.CreateTransaction(transaction);

        //    _repositoryManager.saveChanges();

        //    Account accounReturned = await _repositoryManager.Account.GetAccount(addLoanDto.AccountId, trackChanges: true);

        //    decimal NewBalance = accounReturned.Balance + addLoanDto.Amount;

        //    accounReturned.Balance = NewBalance;
        //    var xxxxxxx = accounReturned;

        //     _repositoryManager.Account.UpdateAccout(accounReturned);

        //    _repositoryManager.saveChanges();


        //    return  mappedLoan;
        //}

        //public Task<PagedList<Customer>> GetAllCustomers(bool trackChanges, RequestParameters requestParameters)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<Customer> GetCustomerByMail(string email)
        //{
        //    return
        //    await _repositoryManager.Customer.GetCustomerByMail(email,trackChanges:false);
        //}

        //public Task<Account> UserTransaction(TransferMoneyUserDto transferMoneyUserDto)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Transaction> TransactionHapp(int accountId, decimal amount, decimal balance, string operation, string type)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<Transaction>> GetTransactions(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public CustomerAndAccounts GetCustomerAndAccounts(int id)
        //{
        //    CustomerAndAccounts customerAndAccounts = new CustomerAndAccounts();
        //    customerAndAccounts.Accounts = new Account();
        //    var disp = _repositoryManager.Disposition;
        //}
    }
}
