namespace PersistenceTests.Repositories.Read.Abstractions;

public interface IReadRepositoryBaseTests
{
    public Task GetById_whenExists();
    public Task GetById_whenNotExists();
}
