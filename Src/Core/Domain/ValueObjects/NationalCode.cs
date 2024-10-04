using System.ComponentModel;

namespace Domain.ValueObjects;

public sealed class NationalCode : SingleValueObject<NationalCode, string>, ICreatableValueObject<NationalCode, string>
{
    [CustomMinLength(10)]
    [CustomMaxLength(10)]
    [BeAllDigits]
    [DisplayName("کد ملی")]
    public override string Value => base.Value;

    private NationalCode(string value) : base(value) { }

    public static Result<NationalCode> Create(string value)
    {
        return new NationalCode(value);
    }
}