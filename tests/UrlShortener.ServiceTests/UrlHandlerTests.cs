using UrlShortener.Application;
using UrlShortener.Service;

namespace UrlShortener.ServiceTests;

public class UrlHandlerTests
{
    private readonly string _longUrl;
    private readonly string _shortUrl;
    private readonly UrlHandler _urlHandler;
    private readonly UrlRequest _urlRequest;
    private readonly Service.UrlShortener _urlShortener = new();

    public UrlHandlerTests()
    {
        _longUrl = "https://www.example.com";
        _shortUrl = _urlShortener.Shorten(_longUrl);
        _urlHandler = new UrlHandler();
        _urlRequest = new UrlRequest(longUrl: _longUrl);
    }
    [Fact]
    public void AddUrls_WhenPassingLongUrl_ItShouldReturnShort()
    {
        var shortUrl = _urlHandler.AddUrl(_urlRequest);

        Assert.Equal(expected: _shortUrl, actual: shortUrl);
    }

    [Fact]
    public void GetLongUrl_WhenPassingShortUrl_ItShouldReturnLongUrl()
    {
        _urlHandler.AddUrl(_urlRequest);

        var longUrl = _urlHandler.GetLongUrl(_shortUrl);

        Assert.Equal(expected: _longUrl, actual: longUrl);
    }

    [Fact]
    public void GetLongUrl_WhenPassingShortUrl_ItShouldReturnEmptyString()
    {
        var longUrl = _urlHandler.GetLongUrl(string.Empty);

        Assert.Equal(expected: string.Empty, actual: longUrl);
    }
}
