using Domain.Entities;
using Domain.Interfaces.Persistence.Repositories.Read;
using Domain.Interfaces.Persistence.Repositories.Write;
using Domain.ValueObjects;
using FluentAssertions;
using PersistenceTests.Repositories.Common;
using PersistenceTests.Repositories.Read.Common;
using Xunit.Abstractions;

namespace PersistenceTests.Repositories.Read;

public class ReadCustomerRepositoryTests : IReadPersonRoleRepositoryTests
{
    readonly IReadCustomersRepository _readRepository;
    readonly IWriteCustomersRepository _writeRepository;

    public ReadCustomerRepositoryTests(ITestOutputHelper output)
    {
        var provider = new RepositoryProvider();
        _readRepository = provider.Get<IReadCustomersRepository>();
        _writeRepository = provider.Get<IWriteCustomersRepository>();

        output.WriteLine(provider.DataBaseId);
    }

    [Fact]
    public void GetById_whenExists()
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

        _writeRepository.Add(customer);

        var result = _readRepository.Get(customer.Id);

        result
            .Should()
            .NotBeNull();

        result!
            .Id
            .Should()
            .Be(customer.Id);
    }

    [Fact]
    public void GetById_whenNotExists()
    {
        _readRepository.Get(1)
            .Should()
            .BeNull();
    }

    [Fact]
    public void GetByPhoneNumber_WhenExists()
    {
        var phoneNumber = new PhoneNumber { Value = "09136470184" };
        var customer = new Customer
        {
            PersonalInformation = new() { PhoneNumber = phoneNumber }
        };

        _writeRepository.Add(customer);

        var result = _readRepository.Get(phoneNumber);

        result
            .Should()
            .NotBeNull();

        result!
            .PersonalInformation.PhoneNumber.Value
            .Should()
            .Be(customer.PersonalInformation.PhoneNumber.Value);
    }

    [Fact]
    public void GetByPhoneNumber_whenNotExists()
    {
        _readRepository.Get(new PhoneNumber { Value = "09665559856" })
            .Should()
            .BeNull();
    }

    [Fact]
    public void Exists_whenCustomerExists()
    {
        var phoneNumber = new PhoneNumber { Value = "09156970284" };

        var customer = new Customer()
        {
            PersonalInformation = new()
            {
                PhoneNumber = phoneNumber
            }
        };

        _writeRepository.Add(customer);

        _readRepository.Exists(phoneNumber)
            .Should()
            .BeTrue();
    }

    [Fact]
    public void Exists_whenCustomerNotExists()
    {
        _readRepository.Exists(new PhoneNumber { Value = "09111165555" })
            .Should()
            .BeFalse();
    }
}