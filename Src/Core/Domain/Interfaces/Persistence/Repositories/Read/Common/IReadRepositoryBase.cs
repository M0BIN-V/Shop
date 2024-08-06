using Domain.Entities.Common;
using Domain.Interfaces.Persistence.Repositories.Common;

namespace Domain.Interfaces.Persistence.Repositories.Read.Common;

public interface IReadRepositoryBase<TEntity> : IRepository
    where TEntity : EntityBase
{
    public TEntity? Get(long id);
}
