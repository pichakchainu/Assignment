using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.Base
{
    public class ValidationResult
    {
        public ValidationResult()
        {

        }

        public ValidationResult(IList<ValidationError> errors) : this()
        {
            Errors = errors;
        }
        public IList<ValidationError> Errors { get; set; } = new List<ValidationError>();
        public bool IsValid
        {
            get
            {
                if (Errors.Count() > 0)
                    return false;
                else
                    return true;
            }
        }
    }
    public class ValidationError
    {
        public object AttemptedValue { get; set; }
        public string ErrorMessage { get; set; }
        public string PropertyName { get; set; }
    }
}
