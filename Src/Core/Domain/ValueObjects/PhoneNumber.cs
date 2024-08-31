using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public class PhoneNumber : SingleValueObject<string>
{
    [Phone]
    [MinLength(11)]
    [MaxLength(11)]
    [DisplayName("شماره تلفن")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}