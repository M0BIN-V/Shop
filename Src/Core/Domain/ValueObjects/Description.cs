using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public class Description : SingleValueObject<string>
{
    [MaxLength(500)]
    [DisplayName("توضیحات")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}