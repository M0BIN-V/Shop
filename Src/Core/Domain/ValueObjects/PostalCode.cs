using Domain.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Domain.ValueObjects;

public class PostalCode : SingleValueObject<string>
{
    [MaxLength(10)]
    [MinLength(10)]
    [RegularExpression(RegexValidations.BeAllDigits)]
    [DisplayName("کد پستی")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}