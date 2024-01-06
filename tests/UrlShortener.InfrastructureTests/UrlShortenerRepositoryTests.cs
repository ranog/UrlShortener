namespace UrlShortener.Infrastructure;

public class UrlShortenerRepositoryTests
{
    private readonly string _longUrl;
    private readonly string _shortUrl;

    public UrlShortenerRepositoryTests()
    {
        _longUrl = "https://www.example.com";
        _shortUrl = Service.UrlShortener.Shorten(_longUrl);
        UrlShortenerRepository.Urls.Clear();
    }


    [Fact]
    public void UrlShortenerRepository_WhenPassingShortUrl_ItShouldReturnLongUrl()
    {
        UrlShortenerRepository.Add(shortUrl: _shortUrl, longUrl: _longUrl);

        Assert.Equal(expected: _longUrl, actual: UrlShortenerRepository.Get(_shortUrl));
    }

    [Fact]
    public void UrlShortenerRepository_WhenAddingTheSameUrlOnlyOneShouldBeSavedInTheRepository()
    {
        UrlShortenerRepository.Add(shortUrl: _shortUrl, longUrl: _longUrl);
        UrlShortenerRepository.Add(shortUrl: _shortUrl, longUrl: _longUrl);

        Assert.Single(UrlShortenerRepository.Urls);
    }

    [Fact]
    public void UrlShortenerRepository_WhenAddingDifferentUrlsAll_ItShouldBeSavedInTheRepository()
    {
        const string anotherLongUrl = "https://www.example.com/another";
        var anotherShortUrl = Service.UrlShortener.Shorten(anotherLongUrl);

        UrlShortenerRepository.Add(shortUrl: _shortUrl, longUrl: _longUrl);
        UrlShortenerRepository.Add(shortUrl: anotherShortUrl, longUrl: anotherLongUrl);

        Assert.Equal(expected: 2, actual: UrlShortenerRepository.Urls.Count);
        Assert.Equal(expected: _longUrl, actual: UrlShortenerRepository.Get(_shortUrl));
        Assert.Equal(expected: anotherLongUrl, actual: UrlShortenerRepository.Get(anotherShortUrl));
    }

    [Fact]
    public void UrlShortenerRepository_WhenTheShortUrlDoesNotExist_ItShouldReturnAnEmptyString()
    {
        const string nonexistentShortUrl = "1234567";

        var longUrl = UrlShortenerRepository.Get(nonexistentShortUrl);

        Assert.Equal(expected: string.Empty, actual: longUrl);
    }
}
