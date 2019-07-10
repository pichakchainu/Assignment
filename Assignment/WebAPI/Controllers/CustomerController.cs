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
        public ActionResult<APIResponseWrapper<IEnumerable<CustomerDTO>>> GetCustomerById(int CustomerId)
        {
            ValidationResult validResult = customerValidationService.IsValidationId(CustomerId);
            var result = customerService.GetCustomerById(CustomerId);
            if (result.Count() > 0)
                return APIResponse(customerService.GetCustomerById(CustomerId), validResult);
            else
                return NotFound();
        }

        [HttpGet("query/GetCustomerByEmail")]
        public ActionResult<APIResponseWrapper<IEnumerable<CustomerDTO>>> GetCustomerByEmail(string Email)
        {
            ValidationResult validResult = customerValidationService.IsValidationEmail(Email);
            var result = customerService.GetCustomerDTOByEmail(Email);
            if (result.Count() > 0)
                return APIResponse(result, validResult);
            else
                return NotFound();
        }

        //[HttpGet("query/GetCustomerByCustomerIdAndEmail")]
        //public ActionResult<APIResponseWrapper<IEnumerable<CustomerDTO>>> GetCustomerByCustomerIdAndEmail(int CustomerId, string Email)
        //{
        //    //if (customerValidationService.IsValidationCustomerID(CustomerId) && customerValidationService.IsValidationEmail(Email))
        //    //return APIResponse(customerService.GetCustomerDTOByIdAndEmail(CustomerId, Email));
        //    //else
        //    return BadRequest();
        //}
    }
}