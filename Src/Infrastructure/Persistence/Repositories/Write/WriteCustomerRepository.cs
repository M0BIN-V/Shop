using Domain.Entities;
using Domain.Interfaces.Persistence.Repositories.Write;
using Persistence.DbContexts;
using Persistence.Repositories.Write.Abstractions;

namespace Persistence.Repositories.Write;

public class WriteCustomersRepository : WriteEntityRepositoryBase<Customer>, IWriteCustomersRepository
{
    public WriteCustomersRepository(WriteDbContext context) : base(context)
    {
    }
}
