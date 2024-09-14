namespace Api.ServiceInstallers;

public class ApplicationServicesInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services
           .AddOtpService()
           .AddSmsService()
           .AddApplicationHandlers();
    }
}
