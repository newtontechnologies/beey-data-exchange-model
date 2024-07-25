using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Beey.DataExchangeModel.Common.Enums;

namespace Beey.DataExchangeModel.Common.Attributes;
public class EmailAddressCustomAttribute : ValidationAttribute
{
    private const string EmailLocalPart = @"[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+";
    private const string EmailDomainPart =
        @"(?:" //at least second level domain
        + @"(?!-)" //(sub)domain cannot start with dash
        + @"[a-zA-Z0-9-]{1,61}"
        + @"(?<!-)" //(sub)domain cannot end with dash
        + @"\.)+"; //each subdomain must end with dot;
    private const string EmailTopLevelDomainPart = @"(?!-)"
                                                   + @"[a-zA-Z0-9-]{1,61}"
                                                   + @"(?<!-)\z"
                                                   + @"\z";

    // Reworked to be compatible with quanda.. No more internalized local names..
    private static readonly Regex s_emailRegex = new Regex(
        "^"
        + EmailLocalPart
        + "@"
        + EmailDomainPart
        + EmailTopLevelDomainPart,
        RegexOptions.Compiled); 
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var email = value?.ToString(); 

        if (!string.IsNullOrEmpty(email) && !s_emailRegex.IsMatch(email))
        {
            return new ValidationResult($"Email is invalid.", new[] { validationContext.MemberName });
        }

        return ValidationResult.Success;
    }

}
