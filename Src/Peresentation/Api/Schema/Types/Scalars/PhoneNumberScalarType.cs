using HotChocolate.Language;

namespace Api.Schema.Types.Scalars;

public class PhoneNumberScalarType : ScalarType<PhoneNumber, StringValueNode>
{
    public PhoneNumberScalarType(BindingBehavior bind = BindingBehavior.Explicit) : base(nameof(PhoneNumber), bind) { }

    public override IValueNode ParseResult(object? resultValue)
    {
        return ParseValue(resultValue);
    }

    protected override PhoneNumber ParseLiteral(StringValueNode valueSyntax)
    {
        return new PhoneNumber { Value = valueSyntax.Value };
    }

    protected override StringValueNode ParseValue(PhoneNumber runtimeValue)
    {
        return new StringValueNode(runtimeValue.Value);
    }
}