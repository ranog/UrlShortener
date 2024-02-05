using System.Net;
using System.Net.Http.Json;

using Microsoft.AspNetCore.Mvc.Testing;

using UrlShortener.Application;
using UrlShortener.Service;

namespace UrlShortener.WebApiTests.Controllers;

public class ShortenControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly string _longUrl;
    private readonly string _shortUrl;
    private readonly HttpClient _httpClient;
    private readonly UrlRequest _urlRequest;
    private readonly string _uri;
    private readonly Service.UrlShortener _urlShortener = new();


    public ShortenControllerTests(WebApplicationFactory<Program> factory)
    {
        _longUrl = "https://www.dummy.com/";
        _shortUrl = _urlShortener.Shorten(_longUrl);
        _httpClient = factory.CreateDefaultClient();
        _urlRequest = new UrlRequest(longUrl: _longUrl);
        _uri = "api/v1/data/shorten";
    }

    [Fact]
    public async Task Shorten_WhenPassingLongUrl_ItShouldReturnShort()
    {
        var response = await _httpClient.PostAsync(requestUri: _uri, content: JsonContent.Create(_urlRequest));

        Assert.Equal(expected: HttpStatusCode.OK, actual: response.StatusCode);
        Assert.Equal(expected: _shortUrl, actual: await response.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task Shorten_WhenPassingLongUrl_ItShouldReturnShortWith7Characters()
    {
        var response = await _httpClient.PostAsync(requestUri: _uri, content: JsonContent.Create(_urlRequest));

        Assert.Equal(expected: HttpStatusCode.OK, actual: response.StatusCode);
        Assert.Equal(expected: 7, actual: (await response.Content.ReadAsStringAsync()).Length);
    }

    [Theory]
    [InlineData("www.example.com")]
    [InlineData("example.com")]
    [InlineData("example")]
    [InlineData(" ")]
    [InlineData(null)]
    [InlineData("https:")]
    public async Task Shorten_WhenPassingAnInvalidUrl_ItShouldReturnAnErrorMessage(string longUrl)
    {
        var urlRequest = new UrlRequest(longUrl: longUrl);

        var response = await _httpClient.PostAsync(requestUri: _uri, content: JsonContent.Create(urlRequest));

        Assert.Equal(expected: HttpStatusCode.BadRequest, actual: response.StatusCode);
        Assert.Equal(expected: $"Url: {longUrl} is not valid", actual: await response.Content.ReadAsStringAsync());
    }

    [Fact]
    public async Task GetLongUrl_WhenPassingShortUrl_ItShouldReturnLongUrl()
    {
        new UrlHandler().AddUrl(_urlRequest);

        var response = await _httpClient.GetAsync($"api/v1/{_shortUrl}");

        Assert.Equal(expected: HttpStatusCode.Moved, actual: response.StatusCode);
        Assert.Equal(expected: _longUrl, actual: response.Headers.Location?.ToString());
    }

    [Fact]
    public async Task GetLongUrl_WhenPassingShortUrl_ItShouldReturnEmptyString()
    {
        var response = await _httpClient.GetAsync("api/v1/");

        Assert.Equal(expected: HttpStatusCode.NotFound, actual: response.StatusCode);
        Assert.Equal(expected: string.Empty, actual: await response.Content.ReadAsStringAsync());
    }
}
