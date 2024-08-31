using Domain.Validations.Attributes;

namespace DomainTests.Validations.Attributes;

public class UniqueItemAttributeTests
{
    readonly UniqueItemAttribute _attribute = new();

    class TestObject
    {
        public required string Name { get; set; }
    }

    [Fact]
    public void UniqueItem_WithSameObject_ShouldReturnFalse()
    {
        List<string> objects = ["ali", "ali", "ali"];

        _attribute.IsValid(objects)
            .Should()
            .BeFalse();
    }

    [Fact]
    public void UniqueItem_WithoutSameObject_ShouldReturnTrue()
    {
        List<string> objects = ["ali", "ahmad", "reza"];

        _attribute.IsValid(objects)
            .Should()
            .BeTrue();
    }
}
