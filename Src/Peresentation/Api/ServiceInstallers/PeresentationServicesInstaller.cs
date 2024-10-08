﻿namespace Api.ServiceInstallers;

public class PeresentationServicesInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddCors(options => options.AddPolicy(name: "AllowAnyOrigin", policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            }))

            .AddSwaggerGen()
            .AddEndpointsApiExplorer()
            .AddControllers();
    }
}