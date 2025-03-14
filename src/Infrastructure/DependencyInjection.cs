using Microsoft.Extensions.DependencyInjection;
using ShortenUrlApi.Application.Interfaces;
using ShortenUrlApi.Infrastructure.Services;

namespace ShortenUrlApi.Infrastructure;

/// <summary>
/// Contains extension methods for registering infrastructure services
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds infrastructure services to the service collection
    /// </summary>
    /// <param name="services">The service collection to add services to</param>
    /// <returns>The service collection for chaining</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IUrlShortenerService, UrlShortenerService>();
        return services;
    }
} 