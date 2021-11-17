using Entities.Models;
using Entities.Paging;
using Entities.RequestServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICustomerservice
    {
        Task<Customer> GetCustomer(int id, bool trackChanges);
        Task<PagedList<Transaction>> GetTransactions(bool trackChanges, RequestParameters requestParameters);
        Task<Customer> GetCustomerInfo(int id, bool trackChanges);
    }
}
