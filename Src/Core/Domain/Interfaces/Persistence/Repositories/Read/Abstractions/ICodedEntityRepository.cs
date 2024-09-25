using Domain.Entities.Abstractions;

namespace Domain.Interfaces.Persistence.Repositories.Read.Abstractions;

public interface ICodedEntityRepository<TEntity> : IReadRepositoryBase<TEntity>
    where TEntity : EntityBase, ICodedEntity
{
    public Task<TEntity> GetAsync(Guid code);
}
