using System.ComponentModel.DataAnnotations;
using Beey.DataExchangeModel.Common.Enums;
using PhoneNumbers;

namespace Beey.DataExchangeModel.Common.Attributes;
public class PhoneCustomAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {   var phone = value?.ToString();
        if (String.IsNullOrEmpty(phone))
        {
            return ValidationResult.Success;
        }
        try
        {
            if (!PhoneNumberUtil.GetInstance().IsValidNumber(PhoneNumberUtil.GetInstance().Parse(phone, null)))
            {
                return new ValidationResult($"{ErrorTypeEnum.Invalid.GetDescription()}:Format", new[] { validationContext.MemberName });
            }
            return ValidationResult.Success;
        }
        catch (NumberParseException)
        {
            return new ValidationResult($"{ErrorTypeEnum.Invalid.GetDescription()}:Format", new[] { validationContext.MemberName });
            
        }

    }
}
