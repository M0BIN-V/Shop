using Domain.Entities;
using Persistence.Repositories.Read;
using Persistence.Repositories.Write;
using PersistenceTests.Repositories.Common;
using PersistenceTests.Repositories.Write.Abstractions;

namespace PersistenceTests.Repositories.Write;

public class WriteCustomerRepositoryTests : RepositoryBase, IWriteRepositoryBaseTests<Customer>
{
    readonly ReadCustomersRepository _readRepository;
    readonly WriteCustomersRepository _writeRepository;

    public WriteCustomerRepositoryTests()
    {
        _readRepository = new ReadCustomersRepository(_readDbContext);
        _writeRepository = new WriteCustomersRepository(_writeDbContext);
    }

    [Fact]
    public async Task Add()
    {
        var customer = new Customer
        {
            PersonalInformation = new()
            {
                PhoneNumber = new()
                {
                    Value = "09136666666"
                }
            }
        };

        await _writeRepository.AddAsync(customer);

        var exists = await _readRepository.ExistsAsync(customer.PersonalInformation.PhoneNumber);

        exists.Should().BeTrue();
    }
}