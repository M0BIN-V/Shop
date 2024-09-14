using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public class PhoneNumber : SingleValueObject<string>
{
    [Phone(ErrorMessage = "شماره تلفن معتبر نیست")]
    [CustomMinLength(11)]
    [CustomMaxLength(11)]
    [DisplayName("شماره تلفن")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}