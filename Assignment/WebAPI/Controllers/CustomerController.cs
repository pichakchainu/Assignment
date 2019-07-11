using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Core.DomainModels.Customers;
using WebAPI.Helpers;
using WebAPI.Services;
using WebAPI.Services.Base;
using WebAPI.Services.Customers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService customerService;
        private readonly ICustomerValidationService customerValidationService;
        public CustomerController(ICustomerService customerService, ICustomerValidationService customerValidationService)
        {
            this.customerService = customerService;
            this.customerValidationService = customerValidationService;
        }

        [HttpGet("query/GetCustomerById")]
        public async Task<ActionResult<APIResponseWrapper<CustomerDTO>>> GetCustomerById(int CustomerId)
        {
            ValidationResult validResult = customerValidationService.IsValidationId(CustomerId);
            var result = await customerService.GetCustomerByIdAsync(CustomerId);
            return APIResponse(result, validResult);
        }

        [HttpGet("query/GetCustomerByEmail")]
        public async Task<ActionResult<APIResponseWrapper<CustomerDTO>>> GetCustomerByEmail(string Email)
        {
            ValidationResult validResult = customerValidationService.IsValidationEmail(Email);
            var result = await customerService.GetCustomerDTOByEmailAsync(Email);
            return APIResponse(result, validResult);
        }

        [HttpGet("query/GetCustomerByCustomerIdAndEmail")]
        public async Task<ActionResult<APIResponseWrapper<CustomerDTO>>> GetCustomerByCustomerIdAndEmail(int CustomerId, string Email)
        {
            ValidationResult validResult = customerValidationService.IsValidationIdAndEmail(CustomerId, Email);
            var result = await customerService.GetCustomerDTOByIdAndEmailAsync(CustomerId, Email);
            return APIResponse(result, validResult);
        }
    }
}