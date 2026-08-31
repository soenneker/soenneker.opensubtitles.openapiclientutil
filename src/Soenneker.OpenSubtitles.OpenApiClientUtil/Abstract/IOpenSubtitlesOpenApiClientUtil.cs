using Soenneker.OpenSubtitles.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.OpenSubtitles.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached OpenSubtitles REST API client backed by the configured HTTP provider.
/// </summary>
public interface IOpenSubtitlesOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached OpenSubtitles client, creating it on the first call.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured OpenSubtitles client.</returns>
    ValueTask<OpenSubtitlesOpenApiClient> Get(CancellationToken cancellationToken = default);
}
