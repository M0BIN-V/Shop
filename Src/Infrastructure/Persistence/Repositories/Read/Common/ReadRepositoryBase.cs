using Domain.Entities.Common;
using Domain.Interfaces.Persistence.Repositories.Read.Common;
using Persistence.DbContexts;
using Persistence.Repositories.Common;

namespace Persistence.Repositories.Read.Common;

internal abstract class ReadRepositoryBase<TEntity> : RepositoryBase<TEntity>, IReadRepositoryBase<TEntity>
    where TEntity : EntityBase
{
    protected ReadRepositoryBase(ReadDbContext context) : base(context) { }

    public TEntity? Get(long id)
    {
        return _set.FirstOrDefault(x => x.Id == id);
    }
}
