using Domain.Entities;
using Domain.Interfaces.Persistence.Repositories.Write;
using Persistence.DbContexts;
using Persistence.Repositories.Write.Abstractions;

namespace Persistence.Repositories.Write;

internal class WriteCustomerRepository : WriteEntityRepositoryBase<Customer>, IWriteCustomersRepository
{
    public WriteCustomerRepository(ReadDbContext context) : base(context)
    {
    }
}
