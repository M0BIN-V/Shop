using Domain.Interfaces.Persistence.Repositories.Read.Abstractions;

namespace Domain.Interfaces.Persistence.Repositories.Read;

public interface IReadProductsRepository : ICodedEntityRepository<Product>
{
    public Task<bool> ExistsAsync(Name Name);

}
