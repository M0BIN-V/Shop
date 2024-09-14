using System.ComponentModel;

namespace Domain.ValueObjects;

public class Title : SingleValueObject<string>
{
    [CustomMinLength(3)]
    [CustomMaxLength(100)]
    [DisplayName("عنوان")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}