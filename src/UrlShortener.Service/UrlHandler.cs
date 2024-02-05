using UrlShortener.Application;
using UrlShortener.Infrastructure;

namespace UrlShortener.Service;

public class UrlHandler
{
    private readonly UrlShortenerRepository _urlShortenerRepository;
    private readonly UrlShortener _urlShortener;

    public UrlHandler(UrlShortenerRepository urlShortenerRepository, UrlShortener urlShortener)
    {
        _urlShortenerRepository = urlShortenerRepository;
        _urlShortener = urlShortener;
    }

    public string AddUrl(UrlRequest request)
    {
        var shortUrl = _urlShortener.Shorten(request.LongUrl);
        _urlShortenerRepository.Add(shortUrl, request.LongUrl);
        return shortUrl;
    }

    public string GetLongUrl(string shortUrl) => _urlShortenerRepository.Get(shortUrl);
}
