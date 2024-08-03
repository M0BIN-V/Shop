using Domain.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public class NationalCode : SingleValueObject<string>
{
    [MinLength(10)]
    [MaxLength(10)]
    [RegularExpression(RegexValidations.BeAllDigits)]
    [DisplayName("کد ملی")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}