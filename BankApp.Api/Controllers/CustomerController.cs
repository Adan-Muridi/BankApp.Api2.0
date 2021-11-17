using AutoMapper;
using BankApp.Api.Services;
using Contracts;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankApp.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {

        private readonly IBankService _bankService;
        private IFacade _facade;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };

        public CustomerController(IRepositoryManager repositoryManager,
            UserManager<IdentityUser> userManager, IMapper mapper, IBankService bankService, IFacade facade)
        {
            _mapper = mapper;
            _userManager = userManager;

            _bankService = bankService;
            _facade = facade;
        }

        [HttpGet("GetCustomerByMail/{email}")]
        public async Task<IActionResult> GetCustomerByMail(string email)
        {
                var customer = await _bankService.GetCustomerByMail(email);
            if (customer == null)
            {
                _logger.LogInfo($"Customer dose not in database");
                return NotFound();
            }
            else
            {
                string serializedCustomer = System.Text.Json.JsonSerializer.Serialize(customer, _options);
                return Ok(serializedCustomer);
            }

        }
        [HttpPost("TransferMoneyUser")]
        public async Task<IActionResult> TransferMoneyUser([FromBody] TransferMoneyUserDto transferMoneyUserDto)
        {
            if (transferMoneyUserDto == null)
            {
                return BadRequest("Dto object is null");
            }
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            await _bankService.UserTransaction(transferMoneyUserDto);

            return StatusCode(200);


        }

        [HttpGet("GetCustomerTransactions/{id}")]
        public async Task<IActionResult> GetCustomerTransactions(int id)
        {
            var transaction = await _bankService.GetTransactions(id);

            string resultTransactions = System.Text.Json.JsonSerializer.Serialize(transaction, _options);

            return Ok(resultTransactions);
        }





    }
}
