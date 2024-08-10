namespace PersistenceTests.Repositories.Read.Abstractions;

public interface IReadRepositoryBaseTests
{
    public void GetById_whenExists();
    public void GetById_whenNotExists();
}
