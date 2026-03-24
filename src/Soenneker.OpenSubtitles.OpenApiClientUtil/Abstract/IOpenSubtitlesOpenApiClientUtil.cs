using Soenneker.OpenSubtitles.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.OpenSubtitles.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IOpenSubtitlesOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<OpenSubtitlesOpenApiClient> Get(CancellationToken cancellationToken = default);
}
