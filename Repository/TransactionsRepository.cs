using Contracts;
using Entities.Context;
using Entities.Models;
using Entities.RequestServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TransactionsRepository : RepositoryBase<Transaction>, ITransactionsRepository
    {

        public TransactionsRepository(BankDbContext bankDbContext) : base(bankDbContext)
        {

        }

        public void CreateTransaction(Transaction transaction)
        {
            Create(transaction);
        }

        public async Task<List<Transaction>> GetTransactions(int id)
        {
            return await FindByCondition(t => t.AccountId == id, trackChanges: false).ToListAsync();
        }
    }
}





