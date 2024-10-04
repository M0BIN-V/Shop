using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public sealed class PhoneNumber : SingleValueObject<PhoneNumber, string>, ICreatableValueObject<PhoneNumber, string>
{
    [Phone(ErrorMessage = "شماره تلفن معتبر نیست")]
    [CustomMinLength(11)]
    [CustomMaxLength(11)]
    [DisplayName("شماره تلفن")]
    public override string Value => base.Value;

    private PhoneNumber(string value) : base(value) { }

    public static Result<PhoneNumber> Create(string value)
    {
        return new PhoneNumber(value);
    }
}