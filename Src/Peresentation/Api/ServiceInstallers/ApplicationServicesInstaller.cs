using Auth;

namespace Api.ServiceInstallers;

public class ApplicationServicesInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services
           .Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)))
           .AddAuthServices()

           .AddOtpService()
           .AddSmsService()
           .AddApplicationHandlers();
    }
}