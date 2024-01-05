using UrlShortener.Application;

namespace UrlShortener.Infrastructure;

public class UrlShortenerRepositoryTests
{
    [Fact]
    public void UrlShortenerRepository_WhenPassingShortUrl_ItShouldReturnLongUrl()
    {
        const string longUrl = "https://www.example.com";
        var shortUrl = ShortenUrl.Shorten(longUrl);

        UrlShortenerRepository.Add(shortUrl, longUrl);

        Assert.Equal(expected: longUrl, actual: UrlShortenerRepository.Get(shortUrl));
    }

    [Fact]
    public void UrlShortenerRepository_WhenAddingTheSameUrlOnlyOneShouldBeSavedInTheRepository()
    {
        const string longUrl = "https://www.example.com";
        var shortUrl = ShortenUrl.Shorten(longUrl);

        UrlShortenerRepository.Add(shortUrl, longUrl);
        UrlShortenerRepository.Add(shortUrl, longUrl);

        Assert.Single(UrlShortenerRepository.Urls);
    }

    [Fact]
    public void UrlShortenerRepository_WhenAddingDifferentUrlsAll_ItShouldBeSavedInTheRepository()
    {
        const string longUrl1 = "https://www.example.com";
        const string longUrl2 = "https://www.example.com/another";
        var shortUrl1 = ShortenUrl.Shorten(longUrl1);
        var shortUrl2 = ShortenUrl.Shorten(longUrl2);

        UrlShortenerRepository.Add(shortUrl1, longUrl1);
        UrlShortenerRepository.Add(shortUrl2, longUrl2);

        Assert.Equal(expected: 2, actual: UrlShortenerRepository.Urls.Count);
        Assert.Equal(expected: longUrl1, actual: UrlShortenerRepository.Get(shortUrl1));
        Assert.Equal(expected: longUrl2, actual: UrlShortenerRepository.Get(shortUrl2));
    }

    [Fact]
    public void UrlShortenerRepository_WhenTheShortUrlDoesNotExist_ItShouldReturnAnEmptyString()
    {
        const string shortUrl = "1234567";

        var longUrl = UrlShortenerRepository.Get(shortUrl);

        Assert.Equal(expected: string.Empty, actual: longUrl);
    }
}
