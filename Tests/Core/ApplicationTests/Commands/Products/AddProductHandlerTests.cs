using Application.Commands.Products;
using Application.Common.Dtos;
using Domain.Errors;
using Domain.Interfaces.Persistence.Repositories.Read;
using Domain.Interfaces.Persistence.Repositories.Write;

namespace ApplicationTests.Commands.Products;

public class AddProductHandlerTests
{
    readonly AddProductHandler _handler;
    readonly Mock<IReadProductsRepository> _readProductsRepository = new();
    readonly Mock<IWriteProductRepository> _writeProductsRepository = new();
    readonly AddProductCommand _command;

    public AddProductHandlerTests()
    {
        var productDto = new AddProductDto()
        {
            Name = new Name { Value = "MyProduct" },
            Amount = 10_000_000,
            Specifications = [new() { Title = new Title { Value = "size" } }],
            StockQuantity = 1000
        };
        _command = new(productDto);

        _handler = new AddProductHandler(_writeProductsRepository.Object, _readProductsRepository.Object);
    }

    [Fact]
    public async Task AddProductHandler_WithNewProductName_ShouldReturnSuccess()
    {
        _readProductsRepository.Setup(x => x.ExistsAsync(_command.Product.Name).Result).Returns(false);

        var result = await _handler.Handle(_command, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task AddProductHandler_WithRepetitiveProductName_ShouldReturnSuccess()
    {
        _readProductsRepository.Setup(x => x.ExistsAsync(_command.Product.Name).Result).Returns(true);

        var result = await _handler.Handle(_command, CancellationToken.None);

        result.IsSuccess.Should().BeFalse();
        result.Errors[0].GetType().Should().Be(typeof(ProductAlreadyExistsError));
    }
}
