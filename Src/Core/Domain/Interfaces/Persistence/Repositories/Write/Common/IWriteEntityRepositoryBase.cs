using Domain.Entities.Common;

namespace Domain.Interfaces.Persistence.Repositories.Write.Common;

public interface IWriteEntityRepositoryBase<TEntity>
    where TEntity : EntityBase
{
    public void Add(TEntity entity);
}
