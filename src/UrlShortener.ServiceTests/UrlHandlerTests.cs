using UrlShortener.Application;
using UrlShortener.Infrastructure;
using UrlShortener.Service;

namespace UrlShortener.ServiceTests;

public class UrlHandlerTests
{
    [Fact]
    public void Shorten_WhenPassingLongUrl_ItShouldReturnShort()
    {
        const string longUrl = "https://www.example.com";
        var expectedShortUrl = ShortenUrl.Shorten(longUrl);
        var urlRequest = new UrlRequest(longUrl: longUrl, shortUrl: expectedShortUrl);

        var shortUrl = UrlHandler.Shorten(urlRequest);

        Assert.Equal(expected: expectedShortUrl, actual: shortUrl);
    }

    [Fact]
    public void GetLongUrl_WhenPassingShortUrl_ItShouldReturnLongUrl()
    {
        const string expectedLongUrl = "https://www.example.com";
        var shortUrl = ShortenUrl.Shorten(expectedLongUrl);
        var urlRequest = new UrlRequest(longUrl: expectedLongUrl, shortUrl: shortUrl);
        UrlShortenerRepository.Add(urlRequest.ShortUrl, urlRequest.LongUrl);

        var longUrl = UrlHandler.GetLongUrl(urlRequest);

        Assert.Equal(expected: expectedLongUrl, actual: longUrl);
    }

    [Fact]
    public void GetLongUrl_WhenPassingShortUrl_ItShouldReturnEmptyString()
    {
        const string shortUrl = "1234567";
        var urlRequest = new UrlRequest(longUrl: string.Empty, shortUrl: shortUrl);

        var longUrl = UrlHandler.GetLongUrl(urlRequest);

        Assert.Equal(expected: string.Empty, actual: longUrl);
    }
}
