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
    public interface ICustomerRepository
    {
        //Task<IEnumerable<Customer>> GetAllCustomers(bool trackChanges ,CustomerParameters CustomerParameters);
        //Task<PagedList<Customer>> GetCustomers();
        Task<PagedList<Customer>> GetAllCustomers(bool trackChanges, RequestParameters requestParameters);
        Task<Customer> GetCustomer(int id, bool trackChanges);
        Task<Customer> GetCustomerByMail(string email, bool trackChanges);
        void CreateCustomer(Customer customer);

        Task<Customer> GetCreatedCustomer(string Email, bool trackChanges);

        void DeleteCustomer(Customer customer);

        

    }
}