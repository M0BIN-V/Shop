using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public class Address : SingleValueObject<string>
{
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("آدرس")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}