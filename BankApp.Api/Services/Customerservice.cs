using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.Paging;
using Entities.RequestServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Api.Services
{
    public class Customerservice : ICustomerservice
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private IFacade _facade;

        public Customerservice(IRepositoryManager repositoryManager ,IMapper mapper,IFacade facade)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _facade = facade;
        }

        public Task<Customer> GetCustomer(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerInfo(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<Transaction>> GetTransactions(bool trackChanges, RequestParameters requestParameters)
        {
            throw new NotImplementedException();
        }


    }
}
