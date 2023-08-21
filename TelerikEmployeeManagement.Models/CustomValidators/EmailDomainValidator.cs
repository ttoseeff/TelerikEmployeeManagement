using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikEmployeeManagement.Models.CustomValidators
{
    public class EmailDomainValidator : ValidationAttribute
    {
        public string AllowedDomain { get; set; }

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            if (value?.ToString()?.Split("@")?.Length > 1)
            {
                string[]? strings = value?.ToString()?.Split('@');
                if (strings?[1].ToUpper() == AllowedDomain.ToUpper())
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

            return new ValidationResult(ErrorMessage,
            new[] { validationContext.MemberName });
        }
    }
}
