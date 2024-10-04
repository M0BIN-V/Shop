using Domain.Entities.Product;
using Persistence.Repositories.Read;
using PersistenceTests.Repositories.Common;
using PersistenceTests.Repositories.Read.Abstractions;

namespace PersistenceTests.Repositories.Read;

public class ReadProductRepositoryTests : RepositoryTestsBase, IReadRepositoryBaseTests
{
    readonly ReadProductRepository _repository;
    readonly Product _product = new()
    {
        Name = Name.Create("ali")!,
        StockQuantity = 20,
    };

    public ReadProductRepositoryTests()
    {
        _repository = new(_readDbContext);
    }

    [Fact]
    public async Task GetById_WhenExists_ShouldReturnEntity()
    {
        AddProductToDb();

        var result = await _repository.GetAsync(_product.Id);

        result
            .Should()
            .NotBeNull();

        result!
            .Id
            .Should()
            .Be(_product.Id);
    }

    [Fact]
    public async Task GetById_WhenNotExists_ShouldReturnNull()
    {
        var result = await _repository.GetAsync(1);

        result
             .Should()
             .BeNull();
    }

    [Fact]
    public async Task ExistsByName_WhenExists_ShouldReturnTrue()
    {
        AddProductToDb();

        (await _repository.ExistsAsync(_product.Name)).Should().BeTrue();
    }

    [Fact]
    public async Task ExistsByName_WhenNotExists_ShouldReturnFalse()
    {
        (await _repository.ExistsAsync(_product.Name)).Should().BeFalse();
    }

    [Fact]
    public async Task ExistsById_WhenExists_ShouldReturnTrue()
    {
        AddProductToDb();

        (await _repository.ExistsAsync(_product.Id)).Should().BeTrue();
    }

    [Fact]
    public async Task ExistsById_WhenNotExists_ShouldReturnFalse()
    {
        (await _repository.ExistsAsync(_product.Id)).Should().BeFalse();
    }

    async void AddProductToDb()
    {
        await _writeDbContext.Products.AddAsync(_product);
        await _writeDbContext.SaveChangesAsync();
    }
}
