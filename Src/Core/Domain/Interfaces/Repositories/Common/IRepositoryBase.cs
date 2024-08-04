namespace Domain.Interfaces.Repositories.Common;

public interface IRepositoryBase<TEntity>
{
    public TEntity GetById(long id);
    public List<TEntity> GetAll();
}
