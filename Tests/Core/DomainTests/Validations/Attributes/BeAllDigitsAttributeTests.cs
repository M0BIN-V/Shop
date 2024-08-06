using Domain.Validations.Attributes;

namespace DomainTests.Validations.Attributes;

public class BeAllDigitsAttributeTests
{
    readonly BeAllDigitsAttribute _attribute = new();

    [Fact]
    public void WithInvalidValue()
    {
        _attribute
            .IsValid("this is 2342 value")
            .Should()
            .BeFalse();
    }

    [Fact]
    public void WithValidValue()
    {
        _attribute
            .IsValid("this is 2342 value")
            .Should()
            .BeFalse();
    }
}
