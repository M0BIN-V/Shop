using Application;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace ApplicationTests.Common;

public class MediatorProvider
{
    public string DbId = Guid.NewGuid().ToString();

    public IMediator Get()
    {
        var mediator = new ServiceCollection()
            .AddReadRepositories(optionsAction => optionsAction.UseInMemoryDatabase(DbId))
            .AddReadRepositories(optionsAction => optionsAction.UseInMemoryDatabase(DbId))
            .AddApplicationHandlers()
            .BuildServiceProvider()
            .GetRequiredService<IMediator>();

        return mediator;
    }
}
