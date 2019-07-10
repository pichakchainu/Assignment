using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.Base;

namespace WebAPI.Services.Customers
{
    public interface ICustomerValidationService
    {
        ValidationResult IsValidationId(int id);
        ValidationResult IsValidationEmail(string email);
        ValidationResult IsValidationIdAndEmail(int id, string email);
    }
}
