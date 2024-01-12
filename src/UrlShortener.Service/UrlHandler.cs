using UrlShortener.Application;
using UrlShortener.Infrastructure;

namespace UrlShortener.Service;

public class UrlHandler
{
    private readonly UrlShortenerRepository _urlShortenerRepository = new();

    public string AddUrl(UrlRequest request)
    {
        var shortUrl = UrlShortener.Shorten(request.LongUrl);
        _urlShortenerRepository.Add(shortUrl, request.LongUrl);
        return shortUrl;
    }

    public string GetLongUrl(string shortUrl) => _urlShortenerRepository.Get(shortUrl);
}
