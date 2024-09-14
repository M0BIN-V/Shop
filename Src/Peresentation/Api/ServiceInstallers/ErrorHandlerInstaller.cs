using Resulver.AspNetCore.WebApi;

namespace Api.ServiceInstallers;

public class ErrorHandlerInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services
             .AddErrorProfilesFromAssembly(typeof(ErrorHandlerInstaller).Assembly)
             .AddErrorResponseGenerator();
    }
}
