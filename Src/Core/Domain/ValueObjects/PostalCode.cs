using System.ComponentModel;

namespace Domain.ValueObjects;

public class PostalCode : SingleValueObject<string>
{
    [CustomMaxLength(10)]
    [CustomMinLength(10)]
    [BeAllDigits]
    [DisplayName("کد پستی")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}