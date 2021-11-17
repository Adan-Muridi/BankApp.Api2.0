using Contracts;
using Entities.Context;
using Entities.Models;
using Entities.Paging;
using Entities.RequestServices;

using Microsoft.EntityFrameworkCore;
using Repository.Extetions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(BankDbContext bankDbContext) : base(bankDbContext)
        {

        }

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            Delete(customer);
        }

        //public async Task<IEnumerable<Customer>> GetAllCustomers(bool trackChanges, CustomerParameters CustomerParameters)
        //{
        //    return
        //      await FindAll(trackChanges).Search(CustomerParameters.SearchTerm)
        //      .OrderBy(c => c.Emailaddress)
        //     .ToListAsync();
        //}


        public async Task<PagedList<Customer>> GetAllCustomers(bool trackChanges, RequestParameters requestParameters)
        {
            var customers = await FindAll(trackChanges)
                .Search(requestParameters.SearchTerm)
                .ToListAsync();
            return PagedList<Customer>
                .ToPagedList(customers, requestParameters.PageNumber, requestParameters.PageSize);
        }



        public async Task<Customer> GetCreatedCustomer(string email, bool trackChanges)
        {
            return await FindByCondition(c => c.Emailaddress.Equals(email), trackChanges)
                .Include(d=>d.Dispositions).ThenInclude(a=>a.Account).ThenInclude(t=>t.AccountTypes).SingleOrDefaultAsync();
        }

        public async Task<Customer> GetCustomer(int id, bool trackChanges)
        {

            return await FindByCondition(c => c.CustomerId.Equals(id), trackChanges)
                .Include(d => d.Dispositions).ThenInclude(a => a.Account).ThenInclude(t => t.AccountTypes).SingleOrDefaultAsync();

        }
        public async Task<Customer> GetCustomerByMail(string email, bool trackChanges)
        {

            return await FindByCondition(c => c.Emailaddress.Equals(email), trackChanges)
                .Include(d => d.Dispositions).ThenInclude(a => a.Account).ThenInclude(t => t.AccountTypes).SingleOrDefaultAsync();

        }
       
     
    }
}
