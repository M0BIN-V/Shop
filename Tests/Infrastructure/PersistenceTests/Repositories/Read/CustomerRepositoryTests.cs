using Domain.Entities;
using Domain.Interfaces.Persistence.Repositories.Read;
using Domain.Interfaces.Persistence.Repositories.Write;
using Domain.ValueObjects;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using PersistenceTests.Repositories.Read.Common;

namespace PersistenceTests.Repositories.Read;

public class CustomerRepositoryTests : IReadPersonRoleRepositoryTests
{
    readonly IReadCustomersRepository _readRepository;
    readonly IWriteCustomersRepository _writeRepository;

    public CustomerRepositoryTests()
    {
        var services = new ServiceCollection()
            .AddReadRepositories(options => options.UseInMemoryDatabase("InMemoryDb"))
            .AddWriteRepositories(options => options.UseInMemoryDatabase("InMemoryDb"))
            .BuildServiceProvider();

        _readRepository = services
            .GetRequiredService<IReadCustomersRepository>();

        _writeRepository = services
            .GetRequiredService<IWriteCustomersRepository>();
    }

    [Fact]
    public void GetById()
    {
        var customer = new Customer()
        {
            PersonalInformation = new()
            {
                PhoneNumber = new()
                {
                    Value = "09136970284"
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
    public void GetByPhoneNumber()
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
}
