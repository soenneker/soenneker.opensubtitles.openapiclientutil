using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.OpenSubtitles.HttpClients.Abstract;
using Soenneker.OpenSubtitles.OpenApiClient;
using Soenneker.OpenSubtitles.OpenApiClientUtil.Abstract;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.OpenSubtitles.OpenApiClientUtil;

public sealed class OpenSubtitlesOpenApiClientUtil : IOpenSubtitlesOpenApiClientUtil
{
    private readonly AsyncSingleton<OpenSubtitlesOpenApiClient> _client;

    public OpenSubtitlesOpenApiClientUtil(IOpenSubtitlesOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<OpenSubtitlesOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new OpenSubtitlesOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<OpenSubtitlesOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
