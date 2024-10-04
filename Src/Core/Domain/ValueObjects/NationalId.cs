using System.ComponentModel;

namespace Domain.ValueObjects;

public sealed class NationalId : SingleValueObject<NationalId, string>, ICreatableValueObject<NationalId, string>
{
    [CustomMinLength(11)]
    [CustomMaxLength(11)]
    [BeAllDigits]
    [DisplayName("شناسه ملی")]
    public override string Value => base.Value;

    private NationalId(string value) : base(value) { }

    public static Result<NationalId> Create(string value)
    {
        return new NationalId(value);
    }
}