using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITransactionsRepository
    {
        void CreateTransaction(Transaction transaction);
        Task<List<Transaction>> GetTransactions(int id);
    }
}
