using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public class Name : SingleValueObject<string>
{
    [CustomMinLength(3)]
    [CustomMaxLength(20)]
    [DisplayName("نام")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}
