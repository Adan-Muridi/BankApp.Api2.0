using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Api
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<AddAccountForCustomerDto, Account>().ForSourceMember(x => x.CustomerId, i => i.DoNotValidate()).ReverseMap();

            CreateMap<AddLoanDto, Loan>().ForSourceMember(x => x.CustomerId, i => i.DoNotValidate());

            CreateMap<CreateCustomerDto, Customer>().ForSourceMember(x => x.ConfirmPassword, i => i.DoNotValidate())
               .ForSourceMember(x => x.Password, i => i.DoNotValidate());

            CreateMap<AddAccountDto, Account>();

            CreateMap<Customer,CustomerDto > ();
        }
    }

    }

