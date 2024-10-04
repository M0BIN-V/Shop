using System.ComponentModel;

namespace Domain.ValueObjects;

public sealed class Name : SingleValueObject<Name, string>, ICreatableValueObject<Name, string>
{
    [CustomMinLength(3)]
    [CustomMaxLength(20)]
    [DisplayName("نام")]
    public override string Value => base.Value;

    private Name(string value) : base(value) { }

    public static Result<Name> Create(string value)
    {
        return new Name(value);
    }
}
