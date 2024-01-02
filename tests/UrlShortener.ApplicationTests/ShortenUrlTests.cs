using UrlShortener.Application;

namespace UrlShortener.ApplicationTests;

public class ShortenUrlTests
{
    [Fact]
    public void ShortenUrl_WhenPassingLongUrl_ItShouldReturnShort()
    {
        const string longUrl = "https://www.example.com";

        var shortUrl = ShortenUrl.Shorten(longUrl);

        Assert.True(longUrl.Length > shortUrl.Length);
    }

    [Fact]
    public void ShortenUrl_WhenPassingSameLongUrl_ItShouldReturnSameShort()
    {
        const string longUrl = "https://www.example.com";

        var shortUrl1 = ShortenUrl.Shorten(longUrl);
        var shortUrl2 = ShortenUrl.Shorten(longUrl);

        Assert.Equal(expected: shortUrl1, actual: shortUrl2);
    }

    [Fact]
    public void ShortenUrl_WhenPassingDifferentLongUrl_ItShouldReturnDifferentShort()
    {
        const string longUrl1 = "https://www.example.com";
        const string longUrl2 = "https://www.example.com/another";

        var shortUrl1 = ShortenUrl.Shorten(longUrl1);
        var shortUrl2 = ShortenUrl.Shorten(longUrl2);

        Assert.NotEqual(expected: shortUrl1, actual: shortUrl2);
    }

    [Fact]
    public void ShortenUrl_WhenPassingLongUrl_ItShouldReturnShortWith7Characters()
    {
        const int shortURLSize = 7;
        const string longUrl = "https://www.example.com";

        var shortUrl = ShortenUrl.Shorten(longUrl);

        Assert.Equal(expected: shortURLSize, actual: shortUrl.Length);
    }
}
