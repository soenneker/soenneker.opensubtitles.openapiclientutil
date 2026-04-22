using Soenneker.OpenSubtitles.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.OpenSubtitles.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class OpenSubtitlesOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IOpenSubtitlesOpenApiClientUtil _openapiclientutil;

    public OpenSubtitlesOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IOpenSubtitlesOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
