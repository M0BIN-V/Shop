using Domain.Entities.Common;
using Domain.Interfaces.Persistence.Repositories.Common;

namespace Domain.Interfaces.Persistence.Repositories.Write.Common;

public interface IWriteEntityRepositoryBase<TEntity> : IRepository
    where TEntity : EntityBase
{
    public void Add(TEntity entity);
}
