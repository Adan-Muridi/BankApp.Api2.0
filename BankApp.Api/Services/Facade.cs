using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Api.Services
{
    public class Facade : IFacade
    {


        private Customer _customer { get; set; }
        private Account _account { get; set; }
        private Disposition _disposition { get; set; }

        public Facade()
        {
            _customer = new Customer();
            _account = new Account();
        }

        public void SetCustomer(Customer customer)
        {
            _customer = customer;
        }

        public void SetAccoount(Account account)
        {
            _account = account;
        }

        public Account GetAccount()
        {
            return _account;
        }

        public Customer GetCustomer()
        {
            return _customer;
        }
    }
}

