using Contracts;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(BankDbContext bankDbContext) :base(bankDbContext)
        {

        }
        public void CreateAccount(Account account)
        {
            Create(account);
        }

        public async Task<Account> GetAccount(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.AccountId.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateAccout(Account account)
        {
            Update(account);
            
        }
    }
}
