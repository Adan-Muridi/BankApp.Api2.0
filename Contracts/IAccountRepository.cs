using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAccountRepository
    {
        void CreateAccount(Account account);

        Task<Account> GetAccount(int id, bool trackChanges);

        void UpdateAccout(Account account);
    }
}
