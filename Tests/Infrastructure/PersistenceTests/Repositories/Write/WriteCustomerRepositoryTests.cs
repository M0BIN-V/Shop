using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Write;
using PersistenceTests.Repositories.Common;
using PersistenceTests.Repositories.Write.Abstractions;

namespace PersistenceTests.Repositories.Write;

public class WriteCustomerRepositoryTests : RepositoryTestsBase, IWriteRepositoryBaseTests<Customer>
{
    readonly WriteCustomersRepository _writeRepository;
    readonly Customer _customer = new()
    {
        PersonalInformation = new()
        {
            PhoneNumber = new()
            {
                Value = "09136666666"
            }
        }
    };

    public WriteCustomerRepositoryTests()
    {
        _writeRepository = new WriteCustomersRepository(_writeDbContext);
    }

    [Fact]
    public async Task Add()
    {
        await _writeRepository.AddAsync(_customer);

        var exists = await _readDbContext.Customers.AnyAsync(c => c.Id == _customer.Id);

        exists.Should().BeTrue();
    }
}