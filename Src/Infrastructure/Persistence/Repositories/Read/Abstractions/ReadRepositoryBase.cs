using Domain.Entities.Abstractions;
using Domain.Interfaces.Persistence.Repositories.Read.Abstractions;
using Persistence.DbContexts;
using Persistence.Repositories.Abstractions;

namespace Persistence.Repositories.Read.Abstractions;

public abstract class ReadRepositoryBase<TEntity> : RepositoryBase<TEntity>, IReadRepositoryBase<TEntity>
    where TEntity : EntityBase
{
    protected ReadRepositoryBase(ReadDbContext context) : base(context) { }

    public TEntity? Get(long id)
    {
        return _set.FirstOrDefault(x => x.Id == id);
    }
}
