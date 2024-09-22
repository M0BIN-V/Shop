using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public class FilePath : SingleValueObject<string>
{
    [MaxLength(255)]
    public override required string Value { get => base.Value; init => base.Value = value; }
}
