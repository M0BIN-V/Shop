namespace Api.ServiceInstallers;

public class PresentationServicesInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddSwaggerGen()
            .AddEndpointsApiExplorer()
            .AddControllers();
    }
}