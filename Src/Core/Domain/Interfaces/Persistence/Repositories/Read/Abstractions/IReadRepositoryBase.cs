using Domain.Entities.Abstractions;
using Domain.Interfaces.Persistence.Repositories.Abstractions;

namespace Domain.Interfaces.Persistence.Repositories.Read.Abstractions;

public interface IReadRepositoryBase<TEntity> : IRepository
    where TEntity : EntityBase
{
    public TEntity? Get(long id);
}
