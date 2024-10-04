using Persistence.Repositories.Read;
using PersistenceTests.Repositories.Common;
using PersistenceTests.Repositories.Read.Abstractions;

namespace PersistenceTests.Repositories.Read;

public class ReadCustomerRepositoryTests : RepositoryTestsBase, IReadPersonRoleRepositoryTests
{
    readonly ReadCustomersRepository _repository;
    readonly PhoneNumber _phoneNumber = PhoneNumber.Create("09165565554")!;
    readonly Customer _customer;

    public ReadCustomerRepositoryTests()
    {
        _repository = new ReadCustomersRepository(_readDbContext);

        _customer = new()
        {
            PersonalInformation = new()
            {
                PhoneNumber = _phoneNumber
            }
        };
    }

    [Fact]
    public async Task GetById_WhenExists_ShouldReturnEntity()
    {
        AddCustomerToDb();

        var result = await _repository.GetAsync(_customer.Id);

        result
            .Should()
            .NotBeNull();

        result!
            .Id
            .Should()
            .Be(_customer.Id);
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
    public async Task GetByPhoneNumber_WhenExists_ShouldReturnEntity()
    {
        AddCustomerToDb();

        var result = await _repository.GetAsync(_phoneNumber);

        result
            .Should()
            .NotBeNull();

        result!
            .PersonalInformation.PhoneNumber.Value
            .Should()
            .Be(_customer.PersonalInformation.PhoneNumber.Value);
    }

    [Fact]
    public async Task GetByPhoneNumber_WhenNotExists_ShouldReturnNull()
    {
        var result = await _repository.GetAsync(_phoneNumber);

        result.Should().BeNull();
    }

    [Fact]
    public async Task ExistsByPhoneNumber_WhenCustomerExists_ShouldReturnTrue()
    {
        AddCustomerToDb();

        var exists = await _repository.ExistsAsync(_phoneNumber);

        exists.Should().BeTrue();
    }

    [Fact]
    public async Task ExistsByPhoneNumber_WhenCustomerNotExists_ShouldReturnFalse()
    {
        var exists = await _repository.ExistsAsync(_phoneNumber);

        exists.Should().BeFalse();
    }

    [Fact]
    public async Task ExistsById_WhenExists_ShouldReturnTrue()
    {
        AddCustomerToDb();

        (await _repository.ExistsAsync(_customer.Id)).Should().BeTrue();
    }

    [Fact]
    public async Task ExistsById_WhenNotExists_ShouldReturnFalse()
    {
        (await _repository.ExistsAsync(_customer.Id)).Should().BeFalse();
    }

    async void AddCustomerToDb()
    {
        await _writeDbContext.Customers.AddAsync(_customer);
        await _writeDbContext.SaveChangesAsync();
    }
}