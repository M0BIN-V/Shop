using System.ComponentModel;

namespace Domain.ValueObjects;

public sealed class Address : SingleValueObject<Address, string>, ICreatableValueObject<Address, string>
{
    [CustomMinLength(5)]
    [CustomMaxLength(200)]
    [DisplayName("آدرس")]
    public override string Value => base.Value;

    private Address(string value) : base(value) { }

    public static Result<Address> Create(string value)
    {
        return new Address(value);
    }
}