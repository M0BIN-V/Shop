using Domain.Entities.Abstractions;
using Domain.Interfaces.Persistence.Repositories.Abstractions;

namespace Domain.Interfaces.Persistence.Repositories.Write.Abstractions;

public interface IWriteEntityRepositoryBase<TEntity> : IRepository
    where TEntity : EntityBase
{
    public void Add(TEntity entity);
}
