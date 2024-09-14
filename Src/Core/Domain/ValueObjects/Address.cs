using System.ComponentModel;

namespace Domain.ValueObjects;

public class Address : SingleValueObject<string>
{
    [CustomMinLength(5)]
    [CustomMaxLength(200)]
    [DisplayName("آدرس")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}