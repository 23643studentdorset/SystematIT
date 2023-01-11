using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Identity.Validators
{
    public class DateOfBirthValidator : ValidationAttribute
    {
        private readonly int _dateOfBirthMax = DateTime.UtcNow.AddYears(-17).Year;
        private readonly int _dateOfBirthMin = DateTime.UtcNow.AddYears(-80).Year;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value is DateTime)
                {
                    int dobyear = ((DateTime)value).Year;
                    if (dobyear < _dateOfBirthMin || dobyear > _dateOfBirthMax)
                    {
                        return new ValidationResult($"Minimum age must be between years {_dateOfBirthMin} and {_dateOfBirthMax}");
                    }
                }
            }
           return ValidationResult.Success;
        }
    }
}
