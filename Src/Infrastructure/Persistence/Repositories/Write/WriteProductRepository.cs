using Domain.Interfaces.Persistence.Repositories.Write;
using Persistence.DbContexts;
using Persistence.Repositories.Write.Abstractions;

namespace Persistence.Repositories.Write;

public class WriteProductRepository : WriteEntityRepositoryBase<Product>, IWriteProductRepository
{
    public WriteProductRepository(WriteDbContext context) : base(context)
    {
    }
}
