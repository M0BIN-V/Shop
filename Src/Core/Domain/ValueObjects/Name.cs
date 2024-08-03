using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public class Name : SingleValueObject<string>
{
    [MinLength(3)]
    [MaxLength(20)]
    [DisplayName("نام")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}
