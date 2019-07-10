using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using WebAPI.Services.Base;

namespace WebAPI.Services.Customers
{
    public class CustomerValidationService : ICustomerValidationService
    {
        public ValidationResult IsValidationId(int id)
        {
            var result = new ValidationResult();

            if (id <= 0)
                result.Errors.Add(new ValidationError() { AttemptedValue = id, ErrorMessage = "Invalid Customer ID", PropertyName = "id" });

            return result;
        }

        public ValidationResult IsValidationEmail(string email)
        {
            var result = new ValidationResult();

            if (email == null)
                result.Errors.Add(new ValidationError() { AttemptedValue = email, ErrorMessage = "No inquiry criteria", PropertyName = "email" });
            else if (!IsEmailValid(email))
                result.Errors.Add(new ValidationError() { AttemptedValue = email, ErrorMessage = "Invalid Email", PropertyName = "email" });
            return result;
        }

        private bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public ValidationResult IsValidationIdAndEmail(int id, string email)
        {
            var result = new ValidationResult();
            foreach (var error in IsValidationId(id).Errors)
                result.Errors.Add(error);

            foreach (var error in IsValidationEmail(email).Errors)
                result.Errors.Add(error);

            return result;
        }
    }

}
