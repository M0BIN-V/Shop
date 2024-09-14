using System.ComponentModel;

namespace Domain.ValueObjects;

public class NationalId : SingleValueObject<string>
{
    [CustomMinLength(11)]
    [CustomMaxLength(11)]
    [BeAllDigits]
    [DisplayName("شناسه ملی")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}