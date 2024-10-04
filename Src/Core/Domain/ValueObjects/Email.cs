using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public sealed class Email : SingleValueObject<Email, string>, ICreatableValueObject<Email, string>
{
    [CustomMinLength(4)]
    [CustomMaxLength(255)]
    [EmailAddress(ErrorMessage = "ایمل معتبر نیست.")]
    [DisplayName("ایمیل")]
    public override string Value => base.Value;

    private Email(string value) : base(value) { }

    public static Result<Email> Create(string value)
    {
        return new Email(value);
    }
}
