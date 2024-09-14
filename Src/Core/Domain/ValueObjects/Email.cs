using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public class Email : SingleValueObject<string>
{
    [CustomMinLength(4)]
    [CustomMaxLength(255)]
    [EmailAddress(ErrorMessage ="ایمل معتبر نیست.")]
    [DisplayName("ایمیل")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}
