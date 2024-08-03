using Domain.Validations.Attributes;

namespace DomainTests.Validations.Attributes;

public class BeAllDigitsAttributeTests
{
    readonly BeAllDigitsAttribute _attribute = new();

    [Fact]
    public void InvalidValueTest()
    {
        _attribute
            .IsValid("this is 2342 value")
            .Should()
            .BeFalse();
    }

    [Fact]
    public void ValidValueTest()
    {
        _attribute
            .IsValid("this is 2342 value")
            .Should()
            .BeFalse();
    }
}
