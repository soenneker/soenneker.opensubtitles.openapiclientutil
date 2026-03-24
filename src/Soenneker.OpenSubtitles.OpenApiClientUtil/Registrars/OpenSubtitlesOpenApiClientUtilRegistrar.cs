using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.OpenSubtitles.HttpClients.Registrars;
using Soenneker.OpenSubtitles.OpenApiClientUtil.Abstract;

namespace Soenneker.OpenSubtitles.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class OpenSubtitlesOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="OpenSubtitlesOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddOpenSubtitlesOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddOpenSubtitlesOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IOpenSubtitlesOpenApiClientUtil, OpenSubtitlesOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="OpenSubtitlesOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddOpenSubtitlesOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddOpenSubtitlesOpenApiHttpClientAsSingleton()
                .TryAddScoped<IOpenSubtitlesOpenApiClientUtil, OpenSubtitlesOpenApiClientUtil>();

        return services;
    }
}
