using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;

namespace Persistence.Repositories.Common;

internal abstract class RepositoryBase<TEntity>
where TEntity : EntityBase
{
    protected readonly ReadDbContext _context;
    protected readonly DbSet<TEntity> _set;

    public RepositoryBase(ReadDbContext context)
    {
        _context = context;
        _set = context.Set<TEntity>();
    }
}
