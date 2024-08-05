using Domain.Entities.Common;

namespace Domain.Interfaces.Persistence.Repositories.Read.Common;

public interface IReadRepositoryBase<TEntity>
    where TEntity : EntityBase
{
    public TEntity? Get(long id);
}
