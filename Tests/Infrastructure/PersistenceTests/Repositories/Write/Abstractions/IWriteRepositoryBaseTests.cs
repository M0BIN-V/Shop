using Domain.Entities.Abstractions;

namespace PersistenceTests.Repositories.Write.Abstractions;

internal interface IWriteRepositoryBaseTests<TEntity>
    where TEntity : EntityBase
{
    public Task Add();
}
