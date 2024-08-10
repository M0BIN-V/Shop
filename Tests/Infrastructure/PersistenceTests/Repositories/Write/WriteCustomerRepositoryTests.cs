using Domain.Entities;
using Domain.Interfaces.Persistence.Repositories.Read;
using Domain.Interfaces.Persistence.Repositories.Write;
using PersistenceTests.Repositories.Abstractions;
using PersistenceTests.Repositories.Write.Abstractions;

namespace PersistenceTests.Repositories.Write;

public class WriteCustomerRepositoryTests : IWriteRepositoryBaseTests<Customer>
{
    [Fact]
    public void Add()
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

        var provider = new RepositoryProvider();
        var writeRepository = provider.Get<IWriteCustomersRepository>();
        var readRepository = provider.Get<IReadCustomersRepository>();

        writeRepository.Add(customer);

        readRepository.Exists(customer.PersonalInformation.PhoneNumber)
            .Should().BeTrue();
    }
}