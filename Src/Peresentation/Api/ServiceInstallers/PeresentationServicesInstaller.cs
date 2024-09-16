namespace Api.ServiceInstallers;

public class PeresentationServicesInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddSwaggerGen()
            .AddEndpointsApiExplorer()
            .AddControllers();
    }
}