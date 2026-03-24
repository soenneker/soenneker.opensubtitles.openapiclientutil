using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.OpenSubtitles.HttpClients.Abstract;
using Soenneker.OpenSubtitles.OpenApiClientUtil.Abstract;
using Soenneker.OpenSubtitles.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.OpenSubtitles.OpenApiClientUtil;

///<inheritdoc cref="IOpenSubtitlesOpenApiClientUtil"/>
public sealed class OpenSubtitlesOpenApiClientUtil : IOpenSubtitlesOpenApiClientUtil
{
    private readonly AsyncSingleton<OpenSubtitlesOpenApiClient> _client;

    public OpenSubtitlesOpenApiClientUtil(IOpenSubtitlesOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<OpenSubtitlesOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("OpenSubtitles:ApiKey");
            string authHeaderValueTemplate = configuration["OpenSubtitles:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
