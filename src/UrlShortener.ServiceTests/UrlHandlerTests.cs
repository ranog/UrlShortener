using UrlShortener.Infrastructure;
using UrlShortener.Service;

namespace UrlShortener.ServiceTests;

public class UrlHandlerTests
{
    private readonly string _longUrl;
    private readonly string _shortUrl;

    public UrlHandlerTests()
    {
        _longUrl = "https://www.example.com";
        _shortUrl = ShortenUrl.Shorten(_longUrl);
    }
    [Fact]
    public void AddUrls_WhenPassingLongUrl_ItShouldReturnShort()
    {
        var shortUrl = UrlHandler.AddUrls(_longUrl, _shortUrl);

        Assert.Equal(expected: _shortUrl, actual: shortUrl);
    }

    [Fact]
    public void GetLongUrl_WhenPassingShortUrl_ItShouldReturnLongUrl()
    {
        UrlShortenerRepository.Add(_shortUrl, _longUrl);

        var longUrl = UrlHandler.GetLongUrl(_shortUrl);

        Assert.Equal(expected: _longUrl, actual: longUrl);
    }

    [Fact]
    public void GetLongUrl_WhenPassingShortUrl_ItShouldReturnEmptyString()
    {
        var longUrl = UrlHandler.GetLongUrl(string.Empty);

        Assert.Equal(expected: string.Empty, actual: longUrl);
    }
}
