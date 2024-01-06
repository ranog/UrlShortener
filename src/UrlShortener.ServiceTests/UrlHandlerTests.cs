using UrlShortener.Infrastructure;
using UrlShortener.Service;

namespace UrlShortener.ServiceTests;

public class UrlHandlerTests
{
    [Fact]
    public void AddUrls_WhenPassingLongUrl_ItShouldReturnShort()
    {
        const string longUrl = "https://www.example.com";
        var expectedShortUrl = ShortenUrl.Shorten(longUrl);

        var shortUrl = UrlHandler.AddUrls(longUrl, expectedShortUrl);

        Assert.Equal(expected: expectedShortUrl, actual: shortUrl);
    }

    [Fact]
    public void GetLongUrl_WhenPassingShortUrl_ItShouldReturnLongUrl()
    {
        const string expectedLongUrl = "https://www.example.com";
        var shortUrl = ShortenUrl.Shorten(expectedLongUrl);
        UrlShortenerRepository.Add(shortUrl, expectedLongUrl);

        var longUrl = UrlHandler.GetLongUrl(shortUrl);

        Assert.Equal(expected: expectedLongUrl, actual: longUrl);
    }

    [Fact]
    public void GetLongUrl_WhenPassingShortUrl_ItShouldReturnEmptyString()
    {
        var longUrl = UrlHandler.GetLongUrl(string.Empty);

        Assert.Equal(expected: string.Empty, actual: longUrl);
    }
}
