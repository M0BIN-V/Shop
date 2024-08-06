﻿using Domain.Validations.Attributes;

namespace DomainTests.Validations.Attributes;

public class UniqueItemAttributeTests
{
    readonly UniqueItemAttribute _attribute = new();

    class TestObject
    {
        public required string Name { get; set; }
    }

    [Fact]
    public void InvalidCollectionWithSameObject()
    {
        List<string> objects = ["ali", "ali", "ali"];

        _attribute.IsValid(objects)
            .Should()
            .BeFalse();
    }

    [Fact]
    public void ValidCollectionWithoutSameObjects()
    {
        List<string> objects = ["ali", "ahmad", "reza"];

        _attribute.IsValid(objects)
            .Should()
            .BeTrue();
    }
}
