using System.Net;
using System.Net.Http.Json;

using Microsoft.AspNetCore.Mvc.Testing;

using UrlShortener.Application;
using UrlShortener.Service;

namespace UrlShortener.WebApiTests.Controllers;

public class ShortenControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ShortenControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Shorten_WhenPassingLongUrl_ItShouldReturnShort()
    {
        const string longUrl = "https://www.example.com";
        var expectedShortUrl = ShortenUrl.Shorten(longUrl);
        var urlRequest = new UrlRequest(longUrl: longUrl);
        var httpClient = _factory.CreateClient();

        var response = await httpClient.PostAsync(requestUri: "/v1/shorten", content: JsonContent.Create(urlRequest));

        Assert.Equal(expected: HttpStatusCode.OK, actual: response.StatusCode);
        Assert.Equal(expected: expectedShortUrl, actual: await response.Content.ReadAsStringAsync());
    }
}
