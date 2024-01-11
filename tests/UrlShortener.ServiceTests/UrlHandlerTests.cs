using UrlShortener.Service;

namespace UrlShortener.ServiceTests;

public class UrlHandlerTests
{
    private readonly string _longUrl;
    private readonly string _shortUrl;
    private readonly UrlHandler _urlHandler;

    public UrlHandlerTests()
    {
        _longUrl = "https://www.example.com";
        _shortUrl = Service.UrlShortener.Shorten(_longUrl);
        _urlHandler = new UrlHandler();
    }
    [Fact]
    public void AddUrls_WhenPassingLongUrl_ItShouldReturnShort()
    {
        var shortUrl = _urlHandler.AddUrl(_longUrl, _shortUrl);

        Assert.Equal(expected: _shortUrl, actual: shortUrl);
    }

    [Fact]
    public void GetLongUrl_WhenPassingShortUrl_ItShouldReturnLongUrl()
    {
        _urlHandler.AddUrl(_longUrl, _shortUrl);

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
