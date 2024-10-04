using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public sealed class FilePath : SingleValueObject<FilePath, string>, ICreatableValueObject<FilePath, string>
{
    [MaxLength(255)]
    public override string Value => base.Value;

    private FilePath(string value) : base(value) { }

    public static Result<FilePath> Create(string value)
    {
        return new FilePath(value);
    }
}
