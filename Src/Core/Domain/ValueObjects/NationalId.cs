using Domain.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public class NationalId : SingleValueObject<string>
{
    [MinLength(11)]
    [MaxLength(11)]
    [RegularExpression(RegexValidations.BeAllDigits)]
    [DisplayName("شناسه ملی")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}