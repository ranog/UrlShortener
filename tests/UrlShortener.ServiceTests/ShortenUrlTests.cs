using UrlShortener.Service;

namespace UrlShortener.ServiceTests;

public class ShortenUrlTests
{
    private readonly string _longUrl;
    private readonly string _shortUrl;

    public ShortenUrlTests()
    {
        _longUrl = "https://www.example.com";
        _shortUrl = ShortenUrl.Shorten(_longUrl);
    }

    [Fact]
    public void ShortenUrl_WhenPassingLongUrl_ItShouldReturnShort()
    {
        Assert.True(_longUrl.Length > _shortUrl.Length);
    }

    [Fact]
    public void ShortenUrl_WhenPassingSameLongUrl_ItShouldReturnSameShort()
    {
        var shortUrl = ShortenUrl.Shorten(_longUrl);
        var sameShortUrl = ShortenUrl.Shorten(_longUrl);

        Assert.Equal(expected: shortUrl, actual: sameShortUrl);
    }

    [Fact]
    public void ShortenUrl_WhenPassingDifferentLongUrl_ItShouldReturnDifferentShort()
    {
        const string anotherLongUrl = "https://www.example.com/another";

        var anotherShortUrl = ShortenUrl.Shorten(anotherLongUrl);

        Assert.NotEqual(expected: _shortUrl, actual: anotherShortUrl);
    }

    [Fact]
    public void ShortenUrl_WhenPassingLongUrl_ItShouldReturnShortWith7Characters()
    {
        const int shortUrlSize = 7;

        Assert.Equal(expected: shortUrlSize, actual: _shortUrl.Length);
    }
}
