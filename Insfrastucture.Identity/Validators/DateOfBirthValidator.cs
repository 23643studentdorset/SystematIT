using DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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
            
            DateTime tempValue;
            if (!DateTime.TryParseExact(value.ToString(), "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempValue))
                return new ValidationResult("Date format should be in dd/mm/yyyy format");

            if (tempValue != null)
            {
                if (tempValue is DateTime)
                {
                    int dobyear = ((DateTime)tempValue).Year;
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
