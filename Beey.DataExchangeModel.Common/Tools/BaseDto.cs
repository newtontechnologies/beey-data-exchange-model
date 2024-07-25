using System.ComponentModel.DataAnnotations;

namespace Beey.DataExchangeModel.Tools;
public class BaseDto : IValidatableObject
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();
        // attribute-based validation for required fields and so on
        // Validator.TryValidateObject(this, validationContext, results, true);
        return results;
    }
}
