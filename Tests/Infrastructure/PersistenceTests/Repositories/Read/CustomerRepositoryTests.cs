using Domain.Entities;
using Domain.Interfaces.Persistence.Repositories.Read;
using Domain.Interfaces.Persistence.Repositories.Write;
using Domain.ValueObjects;
using FluentAssertions;
using PersistenceTests.Repositories.Common;
using PersistenceTests.Repositories.Read.Common;

namespace PersistenceTests.Repositories.Read;

public class CustomerRepositoryTests : IReadPersonRoleRepositoryTests
{
    #region GetById

    [Fact]
    public void GetById_whenExists()
    {
        var provider = new RepositoryProvider();
        var readRepository = provider.Get<IReadCustomersRepository>();
        var writeRepository = provider.Get<IWriteCustomersRepository>();

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

        writeRepository.Add(customer);

        var result = readRepository.Get(customer.Id);

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
        var repo = new RepositoryProvider().Get<IReadCustomersRepository>();

        repo.Get(1)
            .Should()
            .BeNull();
    }
    #endregion

    #region GetByPhoneNumber
    [Fact]
    public void GetByPhoneNumber_WhenExists()
    {
        var provider = new RepositoryProvider();
        var readRepository = provider.Get<IReadCustomersRepository>();
        var writeRepository = provider.Get<IWriteCustomersRepository>();

        var phoneNumber = new PhoneNumber { Value = "09136470184" };
        var customer = new Customer
        {
            PersonalInformation = new() { PhoneNumber = phoneNumber }
        };

        writeRepository.Add(customer);

        var result = readRepository.Get(phoneNumber);

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
        var repo = new RepositoryProvider().Get<IReadCustomersRepository>();

        repo.Get(new PhoneNumber { Value = "09665559856" })
            .Should()
            .BeNull();
    }
    #endregion

    #region Exists
    [Fact]
    public void Exists_whenCustomerExists()
    {
        var provider = new RepositoryProvider();
        var readRepository = provider.Get<IReadCustomersRepository>();
        var writeRepository = provider.Get<IWriteCustomersRepository>();

        var phoneNumber = new PhoneNumber { Value = "09156970284" };

        var customer = new Customer()
        {
            PersonalInformation = new()
            {
                PhoneNumber = phoneNumber
            }
        };

        writeRepository.Add(customer);

        readRepository.Exists(phoneNumber)
            .Should()
            .BeTrue();
    }

    [Fact]
    public void Exists_whenCustomerNotExists()
    {
        var provider = new RepositoryProvider();
        var readRepository = provider.Get<IReadCustomersRepository>();

        readRepository.Exists(new PhoneNumber { Value = "09111165555" })
            .Should()
            .BeFalse();
    }
    #endregion
}