using System.ComponentModel.DataAnnotations;

namespace Domain.Validations.Attributes;

public class BeAllDigitsAttribute : RegularExpressionAttribute
{
    public BeAllDigitsAttribute() : base(RegexValidations.BeAllDigits)
    {
        ErrorMessage = "{0} فقط میتواند شامل اعداد باشد.";
    }
}