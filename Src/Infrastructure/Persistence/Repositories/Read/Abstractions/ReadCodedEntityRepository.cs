using Domain.Interfaces.Persistence.Repositories.Read.Abstractions;
using Persistence.DbContexts;

namespace Persistence.Repositories.Read.Abstractions;

public class ReadCodedEntityRepository<TEntity> : ReadRepositoryBase<TEntity>, ICodedEntityRepository<TEntity>
    where TEntity : EntityBase, ICodedEntity
{
    public ReadCodedEntityRepository(ReadDbContext context) : base(context) { }

    public Task<TEntity> GetAsync(Guid code)
    {
        throw new NotImplementedException();
    }
}
