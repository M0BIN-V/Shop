using System.ComponentModel;

namespace Domain.ValueObjects;

public sealed class Description : SingleValueObject<Description, string>, ICreatableValueObject<Description, string>
{
    [CustomMaxLength(500)]
    [DisplayName("توضیحات")]
    public override string Value => base.Value;

    private Description(string value) : base(value) { }

    public static Result<Description> Create(string value)
    {
        return new Description(value);
    }
}