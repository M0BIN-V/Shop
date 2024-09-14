using System.ComponentModel;

namespace Domain.ValueObjects;

public class Description : SingleValueObject<string>
{
    [CustomMaxLength(500)]
    [DisplayName("توضیحات")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}