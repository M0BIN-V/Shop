namespace PersistenceTests.Repositories.Read.Common;

public interface IReadRepositoryBaseTests
{
    public void GetById_whenExists();
    public void GetById_whenNotExists();
}
