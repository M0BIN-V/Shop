using Persistence.Repositories.Read;
using Persistence.Repositories.Write;
using PersistenceTests.Repositories.Common;
using PersistenceTests.Repositories.Read.Abstractions;

namespace PersistenceTests.Repositories.Read;

public class ReadCustomerRepositoryTests : RepositoryTestsBase, IReadPersonRoleRepositoryTests
{
    readonly ReadCustomersRepository _readRepository;

    readonly WriteCustomersRepository _writeRepository;

    public ReadCustomerRepositoryTests()
    {
        _readRepository = new ReadCustomersRepository(_readDbContext);
        _writeRepository = new WriteCustomersRepository(_writeDbContext);
    }

    [Fact]
    public async Task GetById_WhenExists_ShouldReturnEntity()
    {
        var customer = new Customer
        {
            PersonalInformation = new()
            {
                PhoneNumber = new()
                {
                    Value = "09665555987"
                }
            }
        };

        await _writeRepository.AddAsync(customer);

        var result = await _readRepository.GetAsync(customer.Id);

        result
            .Should()
            .NotBeNull();

        result!
            .Id
            .Should()
            .Be(customer.Id);
    }

    [Fact]
    public async Task GetById_WhenNotExists_ShouldReturnNull()
    {
        var result = await _readRepository.GetAsync(1);

        result
             .Should()
             .BeNull();
    }

    [Fact]
    public async Task GetByPhoneNumber_WhenExists_ShouldReturnEntity()
    {
        var phoneNumber = new PhoneNumber { Value = "09136470184" };
        var customer = new Customer
        {
            PersonalInformation = new() { PhoneNumber = phoneNumber }
        };

        await _writeRepository.AddAsync(customer);

        var result = await _readRepository.GetAsync(phoneNumber);

        result
            .Should()
            .NotBeNull();

        result!
            .PersonalInformation.PhoneNumber.Value
            .Should()
            .Be(customer.PersonalInformation.PhoneNumber.Value);
    }

    [Fact]
    public async Task GetByPhoneNumber_WhenNotExists_ShouldReturnNull()
    {
        var result = await _readRepository.GetAsync(new PhoneNumber { Value = "09665559856" });

        result.Should().BeNull();
    }

    [Fact]
    public async Task Exists_WhenCustomerExists_ShouldReturnTrue()
    {
        var phoneNumber = new PhoneNumber { Value = "09156970284" };

        var customer = new Customer()
        {
            PersonalInformation = new()
            {
                PhoneNumber = phoneNumber
            }
        };

        await _writeRepository.AddAsync(customer);

        var exists = await _readRepository.ExistsAsync(phoneNumber);

        exists.Should().BeTrue();
    }

    [Fact]
    public async Task Exists_WhenCustomerNotExists_ShouldReturnFalse()
    {
        var exists = await _readRepository.ExistsAsync(new PhoneNumber { Value = "09111165555" });

        exists.Should().BeFalse();
    }
}