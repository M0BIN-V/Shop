using Domain.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;

namespace Persistence.Repositories.Abstractions;

internal abstract class RepositoryBase<TEntity>
where TEntity : EntityBase
{
    protected readonly ReadDbContext _context;
    protected readonly DbSet<TEntity> _set;

    protected RepositoryBase(ReadDbContext context)
    {
        _context = context;
        _set = context.Set<TEntity>();
    }
}
