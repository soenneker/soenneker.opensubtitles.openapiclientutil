using Soenneker.OpenSubtitles.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.OpenSubtitles.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class OpenSubtitlesOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IOpenSubtitlesOpenApiClientUtil _openapiclientutil;

    public OpenSubtitlesOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IOpenSubtitlesOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
