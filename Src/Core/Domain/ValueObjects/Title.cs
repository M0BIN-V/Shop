using System.ComponentModel;

namespace Domain.ValueObjects;

public sealed class Title : SingleValueObject<Title, string>, ICreatableValueObject<Title, string>
{
    [CustomMinLength(3)]
    [CustomMaxLength(100)]
    [DisplayName("عنوان")]
    public override string Value => base.Value;

    private Title(string value) : base(value) { }

    public static Result<Title> Create(string value)
    {
        return new Title(value);
    }
}