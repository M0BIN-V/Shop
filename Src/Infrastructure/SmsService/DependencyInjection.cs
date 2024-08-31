using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddSmsService
        (this IServiceCollection services)
    {
        services.AddSingleton<ISmsService, SmsService.SmsServiceProvider>();

        return services;
    }
}
