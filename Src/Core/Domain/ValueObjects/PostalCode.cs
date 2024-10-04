using System.ComponentModel;

namespace Domain.ValueObjects;

public sealed class PostalCode : SingleValueObject<PostalCode, string>, ICreatableValueObject<PostalCode, string>
{
    [CustomMaxLength(10)]
    [CustomMinLength(10)]
    [BeAllDigits]
    [DisplayName("کد پستی")]
    public override string Value => base.Value;

    private PostalCode(string value) : base(value) { }

    public static Result<PostalCode> Create(string value)
    {
        return new PostalCode(value);
    }
}