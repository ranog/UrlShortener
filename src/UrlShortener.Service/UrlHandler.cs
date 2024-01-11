using UrlShortener.Infrastructure;

namespace UrlShortener.Service;

public class UrlHandler
{
    private readonly UrlShortenerRepository _urlShortenerRepository = new();

    public string AddUrl(string longUrl, string shortUrl)
    {
        _urlShortenerRepository.Add(shortUrl, longUrl);
        return shortUrl;
    }

    public string GetLongUrl(string shortUrl) => _urlShortenerRepository.Get(shortUrl);
}
