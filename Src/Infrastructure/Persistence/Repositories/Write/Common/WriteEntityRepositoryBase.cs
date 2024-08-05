using Domain.Entities.Common;
using Domain.Interfaces.Persistence.Repositories.Write.Common;
using Persistence.DbContexts;
using Persistence.Repositories.Common;

namespace Persistence.Repositories.Write.Common;

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
