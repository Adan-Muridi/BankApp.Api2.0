using AutoMapper;
using BankApp.Api.Services;
using Contracts;
using Entities.DTOs;
using Entities.Models;
using Entities.RequestServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankApp.Api.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IBankService _bankService; // --
        private IFacade _facade;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };


        public AdminController(UserManager<IdentityUser> userManager, IRepositoryManager repositoryManager,
             IBankService bankService, IFacade facade, ILoggerManager logger, IMapper mapper)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
            _bankService = bankService;
            _facade = facade;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet("gettext")]
        public string GetText()
        {
            return "HEJ FRÅN ADMIN-CONTROLLER!!!! :)";
        }

  

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto createCustomerDto)
        {
            if (createCustomerDto == null)
                return BadRequest("CreateCustomerDto object in null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var user = new IdentityUser{ Email = createCustomerDto.Emailaddress, UserName = createCustomerDto.Emailaddress};

            var userResult = await _userManager.CreateAsync(user, createCustomerDto.Password);
            if (!userResult.Succeeded)
            {
                var errors = userResult.Errors.Select(e => e.Description);
                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }
            await _userManager.AddToRoleAsync(user, "customer");

            var createdCustomer = _bankService.CreateCustomer(createCustomerDto);
            _facade.SetCustomer(createdCustomer);
            
            return StatusCode(201);
        }


        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers([FromQuery] RequestParameters requestParameters)
        {
            var customers = await _repositoryManager.Customer.GetAllCustomers(trackChanges:false,requestParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(customers.MetaData));
            //_logger.LogInfo($"Returned {customers.Count()} customers from database.");

            return Ok(customers);
        }


        [HttpGet("GetCustomer/{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _repositoryManager.Customer.GetCustomer(id,trackChanges: false);
            if(customer==null)
            {
                _logger.LogInfo($"Customer dose not in database");
                return NotFound();
            }
            else
            {
                string serializedCustomer = System.Text.Json.JsonSerializer.Serialize(customer,_options);
                return Ok(serializedCustomer);

            }      

        }

        //  remname
        [HttpPost("AddAccount")]
        public async Task<IActionResult> CreateAccount([FromBody] AddAccountDto addAccountDto)
        {
            if (addAccountDto == null)
            {
                _logger.LogInfo($" No object was passed to endpoint dose not in database");
                return BadRequest("object in null");
            }

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdAccount = _bankService.CreateAccount(addAccountDto);
            var currentCustomer = _facade.GetCustomer();

            var disposition = new Disposition()
            {
                AccountId = createdAccount.AccountId,
                CustomerId=currentCustomer.CustomerId,
            };

            _bankService.CreateDisposion(disposition);


            return StatusCode(201);
        }

        [HttpPost("AddAccountForCustomer")]
        public async Task<IActionResult> AddAccountForCustomer ([FromBody] AddAccountForCustomerDto addAccountForCustomerDto)
        {
            if (addAccountForCustomerDto == null)
            {
                _logger.LogInfo($" No object was passed to endpoint dose not in database");
                return BadRequest("object in null");
            }
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

          
            var createdAccount = _bankService.AddAccountForCustomer(addAccountForCustomerDto);
           

            var disposition = new Disposition()
            {
                AccountId = createdAccount.AccountId,
                CustomerId = addAccountForCustomerDto.CustomerId,
            };

            _bankService.CreateDisposion(disposition);
            return StatusCode(201);
             
        }


        [HttpPost("AddLoanForCustomer")]
        public async Task<IActionResult> AddLoanForCustomer([FromBody] AddLoanDto addLoanDto)
        {
            if (addLoanDto == null)
            {
                _logger.LogInfo($" No object was passed to endpoint dose not in database");
                return BadRequest("object in null");
            }
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);


            await _bankService.AddLoan(addLoanDto);
            //var customer = await _repositoryManager.Customer.GetCustomer(addLoanDto.AccountId, trackChanges: false);
            ////var accU = await _repositoryManager.Account.GetAccount(6,trackChanges:true);
            //var accU2 = await _repositoryManager.Account.GetAccount(addLoanDto.AccountId, trackChanges: false);
            //var x =  await _repositoryManager.Customer.GetCustomer(24,trackChanges:false);
            //var ccccccc = accU;
            //var ccccccc2 = accU2;
            //var customerw = x;
            //var createdAccount = _bankService.AddLoan(addLoanDto);


            //var mappedLoan = _mapper.Map<Loan>(addLoanDto);
            //_repositoryManager.Loan.CreateLoan(mappedLoan);
            //_repositoryManager.saveChanges();



            //Transaction transaction = new Transaction()
            //{
            //    AccountId = addLoanDto.AccountId,
            //    Amount = addLoanDto.Amount,
            //    Date = DateTime.Now,
            //    Type = "Credit"
            //    // Balance = addLoanDto.Amount
            //};
            //_repositoryManager.Transactions.CreateTransaction(transaction);

            //_repositoryManager.saveChanges();

            //Account accounReturned = await _repositoryManager.Account.GetAccount(addLoanDto.AccountId, trackChanges: true);

            //decimal NewBalance = accounReturned.Balance + addLoanDto.Amount;

            //accounReturned.Balance = NewBalance;
            //var xxxxxxx = accounReturned;

            //_repositoryManager.Account.UpdateAccout(accounReturned);

            //_repositoryManager.saveChanges();



            return StatusCode(201);

        }


        //[HttpPost("AddLoan")]

        //public async Task<IActionResult> AddLoan([FromBody] AddLoanDto addLoanDto)
        //{
        //    if (addLoanDto == null)
        //    {
        //        _logger.LogInfo($" No object was passed to endpoint dose not in database");
        //        return BadRequest("object in null");
        //    }
        //    if (!ModelState.IsValid)
        //        return UnprocessableEntity(ModelState);


        //    var createdLoan = _bankService.AddLoan(addLoanDto);


        //}


    }
}
