using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts.Common;

namespace Persistence.Repositories.Abstractions;

public abstract class RepositoryBase<TEntity>
where TEntity : EntityBase
{
    protected readonly DbContextBase _context;
    protected readonly DbSet<TEntity> _entities;

    protected RepositoryBase(DbContextBase context)
    {
        _context = context;
        _entities = context.Set<TEntity>();
    }
}
