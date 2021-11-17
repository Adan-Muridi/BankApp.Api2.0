using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Api.Services
{
    public interface IFacade
    {
        void SetCustomer(Customer customer);

        void SetAccoount(Account account);

        Account GetAccount();

        Customer GetCustomer();
        //    Disposition GetDisposition(int Id);
  
    }
}
