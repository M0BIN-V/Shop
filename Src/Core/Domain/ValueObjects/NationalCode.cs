using System.ComponentModel;

namespace Domain.ValueObjects;

public class NationalCode : SingleValueObject<string>
{
    [CustomMinLength(10)]
    [CustomMaxLength(10)]
    [BeAllDigits]
    [DisplayName("کد ملی")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}