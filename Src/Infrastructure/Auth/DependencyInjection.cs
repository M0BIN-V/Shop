using Application.Interfaces.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace Auth;

public static class DependencyInjection
{
    public static IServiceCollection AddAuthServices
        (this IServiceCollection services)
    {
        services.AddSingleton<IJwtService, JwtService>();

        return services;
    }
}
