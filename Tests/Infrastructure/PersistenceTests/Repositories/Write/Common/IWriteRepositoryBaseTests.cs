using Domain.Entities.Common;

namespace PersistenceTests.Repositories.Write.Common;

internal interface IWriteRepositoryBaseTests<TEntity>
    where TEntity : EntityBase
{
    public void Add();
}
