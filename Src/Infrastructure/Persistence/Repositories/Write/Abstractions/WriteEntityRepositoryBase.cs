using Domain.Entities.Abstractions;
using Domain.Interfaces.Persistence.Repositories.Write.Abstractions;
using Persistence.DbContexts;
using Persistence.Repositories.Abstractions;

namespace Persistence.Repositories.Write.Abstractions;

public class WriteEntityRepositoryBase<TEntity>(WriteDbContext context) :
    RepositoryBase<TEntity>(context), IWriteEntityRepositoryBase<TEntity>
    where TEntity : EntityBase
{
    public void Add(TEntity entity)
    {
        _set.Add(entity);
        _context.SaveChanges();
    }
}
