using Domain.Interfaces.Persistence.Repositories.Read;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;
using Persistence.Repositories.Read.Abstractions;

namespace Persistence.Repositories.Read;

public class ReadProductRepository : ReadCodedEntityRepository<Product>, IReadProductsRepository
{
    public ReadProductRepository(ReadDbContext context) : base(context)
    {
    }

    public Task<bool> ExistsAsync(Name Name)
    {
        return _entities.AnyAsync(t => t.Name == Name);
    }
}
