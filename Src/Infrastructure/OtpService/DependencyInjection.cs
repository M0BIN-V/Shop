using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using OtpService;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddOtpService
        (this IServiceCollection services)
    {
        services.AddSingleton<IOtpService, OtpProvider>();

        return services;
    }
}
