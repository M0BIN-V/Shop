using Domain.Entities.Abstractions;
using Domain.Interfaces.Persistence.Repositories.Write.Abstractions;
using Persistence.DbContexts;
using Persistence.Repositories.Abstractions;

namespace Persistence.Repositories.Write.Abstractions;

internal class WriteEntityRepositoryBase<TEntity> : RepositoryBase<TEntity>, IWriteEntityRepositoryBase<TEntity>
    where TEntity : EntityBase
{
    public WriteEntityRepositoryBase(ReadDbContext context) : base(context) { }

    public void Add(TEntity entity)
    {
        _set.Add(entity);
        _context.SaveChanges();
    }
}
