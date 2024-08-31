using Domain.Validations.Attributes;

namespace DomainTests.Validations.Attributes;

public class BeAllDigitsAttributeTests
{
    readonly BeAllDigitsAttribute _attribute = new();

    [Fact]
    public void BeAllDigits_WithInvalidValue_ShouldReturnFalse()
    {
        _attribute
            .IsValid("this is 2342 value")
            .Should()
            .BeFalse();
    }

    [Fact]
    public void BeAllDigits_WithValidValue_ShouldReturnTrue()
    {
        _attribute
            .IsValid("12455")
            .Should()
            .BeTrue();
    }
}
