using System.ComponentModel;

namespace Domain.ValueObjects;

public class WebSiteAddress : SingleValueObject<string>
{
    [CustomMaxLength(255)]
    [DisplayName("ادرس وبسایت")]
    public override required string Value { get => base.Value; init => base.Value = value; }
}