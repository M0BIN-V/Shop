using System.ComponentModel;

namespace Domain.ValueObjects;

public sealed class WebSiteAddress : SingleValueObject<WebSiteAddress, string>, ICreatableValueObject<WebSiteAddress, string>
{
    [CustomMaxLength(255)]
    [DisplayName("ادرس وبسایت")]
    public override string Value => base.Value;

    private WebSiteAddress(string value) : base(value) { }

    public static Result<WebSiteAddress> Create(string value)
    {
        return new WebSiteAddress(value);
    }
}