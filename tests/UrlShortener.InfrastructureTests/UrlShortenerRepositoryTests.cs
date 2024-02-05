namespace UrlShortener.Infrastructure;

public class UrlShortenerRepositoryTests
{
    private readonly string _longUrl;
    private readonly string _shortUrl;
    private readonly UrlShortenerRepository _urlShortenerRepository = new();
    private readonly Service.UrlShortener _urlShortener = new();

    public UrlShortenerRepositoryTests()
    {
        _longUrl = "https://www.example.com";
        _shortUrl = _urlShortener.Shorten(_longUrl);
        UrlShortenerRepository.Urls.Clear();
    }


    [Fact]
    public void UrlShortenerRepository_WhenPassingShortUrl_ItShouldReturnLongUrl()
    {
        _urlShortenerRepository.Add(shortUrl: _shortUrl, longUrl: _longUrl);

        Assert.Equal(expected: _longUrl, actual: _urlShortenerRepository.Get(_shortUrl));
    }

    [Fact]
    public void UrlShortenerRepository_WhenAddingTheSameUrlOnlyOneShouldBeSavedInTheRepository()
    {
        _urlShortenerRepository.Add(shortUrl: _shortUrl, longUrl: _longUrl);
        _urlShortenerRepository.Add(shortUrl: _shortUrl, longUrl: _longUrl);

        Assert.Single(UrlShortenerRepository.Urls);
    }

    [Fact]
    public void UrlShortenerRepository_WhenAddingDifferentUrlsAll_ItShouldBeSavedInTheRepository()
    {
        const string anotherLongUrl = "https://www.example.com/another";
        var anotherShortUrl = _urlShortener.Shorten(anotherLongUrl);

        _urlShortenerRepository.Add(shortUrl: _shortUrl, longUrl: _longUrl);
        _urlShortenerRepository.Add(shortUrl: anotherShortUrl, longUrl: anotherLongUrl);

        Assert.Equal(expected: 2, actual: UrlShortenerRepository.Urls.Count);
        Assert.Equal(expected: _longUrl, actual: _urlShortenerRepository.Get(_shortUrl));
        Assert.Equal(expected: anotherLongUrl, actual: _urlShortenerRepository.Get(anotherShortUrl));
    }

    [Fact]
    public void UrlShortenerRepository_WhenTheShortUrlDoesNotExist_ItShouldReturnAnEmptyString()
    {
        const string nonexistentShortUrl = "1234567";

        var longUrl = _urlShortenerRepository.Get(nonexistentShortUrl);

        Assert.Equal(expected: string.Empty, actual: longUrl);
    }
}
