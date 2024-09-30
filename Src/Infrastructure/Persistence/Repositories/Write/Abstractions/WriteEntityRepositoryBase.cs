using Domain.Interfaces.Persistence.Repositories.Write.Abstractions;
using Persistence.DbContexts;
using Persistence.Repositories.Abstractions;

namespace Persistence.Repositories.Write.Abstractions;

public class WriteEntityRepositoryBase<TEntity>(WriteDbContext context) :
    RepositoryBase<TEntity>(context), IWriteEntityRepositoryBase<TEntity>
    where TEntity : EntityBase
{
    public async Task AddAsync(TEntity entity)
    {
        await _entities.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
}
