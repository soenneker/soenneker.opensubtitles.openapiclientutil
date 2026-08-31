[![](https://img.shields.io/nuget/v/soenneker.opensubtitles.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.opensubtitles.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.opensubtitles.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.opensubtitles.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.opensubtitles.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.opensubtitles.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.opensubtitles.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.opensubtitles.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.OpenSubtitles.OpenApiClientUtil

Provides a configured OpenSubtitles REST API client and reuses it for the lifetime of the registered service.

## Installation

```bash
dotnet add package Soenneker.OpenSubtitles.OpenApiClientUtil
```

## Configuration

```json
{
  "OpenSubtitles": {
    "ApiKey": "your-application-api-key",
    "Token": "your-user-token"
  }
}
```

`Token` is optional for subtitle searches but required for user-specific operations such as downloads.

## Usage

```csharp
using Soenneker.OpenSubtitles.OpenApiClientUtil.Abstract;
using Soenneker.OpenSubtitles.OpenApiClientUtil.Registrars;

services.AddOpenSubtitlesOpenApiClientUtilAsSingleton();

IOpenSubtitlesOpenApiClientUtil openSubtitles = serviceProvider
    .GetRequiredService<IOpenSubtitlesOpenApiClientUtil>();

var client = await openSubtitles.Get(cancellationToken);
var subtitles = await client.Subtitles.GetAsync(request =>
{
    request.QueryParameters.Query = "Arrival";
    request.QueryParameters.Languages = "en";
}, cancellationToken);
```

Use `AddOpenSubtitlesOpenApiClientUtilAsScoped()` when each application scope should have its own generated client wrapper. The underlying authenticated HTTP provider remains shared and is disposed by the service container at shutdown.
