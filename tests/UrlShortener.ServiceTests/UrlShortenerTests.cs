namespace UrlShortener.ServiceTests;

public class UrlShortenerTests
{
    private readonly string _longUrl;
    private readonly string _shortUrl;

    public UrlShortenerTests()
    {
        _longUrl = "https://www.example.com";
        _shortUrl = Service.UrlShortener.Shorten(_longUrl);
    }

    [Fact]
    public void ShortenUrl_WhenPassingLongUrl_ItShouldReturnShort()
    {
        Assert.True(_longUrl.Length > _shortUrl.Length);
    }

    [Fact]
    public void ShortenUrl_WhenPassingSameLongUrl_ItShouldReturnSameShort()
    {
        var shortUrl = Service.UrlShortener.Shorten(_longUrl);
        var sameShortUrl = Service.UrlShortener.Shorten(_longUrl);

        Assert.Equal(expected: shortUrl, actual: sameShortUrl);
    }

    [Fact]
    public void ShortenUrl_WhenPassingDifferentLongUrl_ItShouldReturnDifferentShort()
    {
        const string anotherLongUrl = "https://www.example.com/another";

        var anotherShortUrl = Service.UrlShortener.Shorten(anotherLongUrl);

        Assert.NotEqual(expected: _shortUrl, actual: anotherShortUrl);
    }

    [Fact]
    public void ShortenUrl_WhenPassingLongUrl_ItShouldReturnShortWith7Characters()
    {
        const int shortUrlSize = 7;

        Assert.Equal(expected: shortUrlSize, actual: _shortUrl.Length);
    }
}
