using UrlShortener.Application;
using UrlShortener.Infrastructure;

namespace UrlShortener.Service;

public abstract class UrlHandler
{
    public static string Shorten(UrlRequest request)
    {
        UrlShortenerRepository.Add(request.ShortUrl, request.LongUrl);
        return request.ShortUrl;
    }

    public static string GetLongUrl(UrlRequest request)
    {
        return UrlShortenerRepository.Get(request.ShortUrl);
    }
}
