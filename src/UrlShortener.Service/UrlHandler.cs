using UrlShortener.Infrastructure;

namespace UrlShortener.Service;

public abstract class UrlHandler
{
    public static string AddUrls(string longUrl, string shortUrl)
    {
        UrlShortenerRepository.Add(shortUrl, longUrl);
        return shortUrl;
    }

    public static string GetLongUrl(string shortUrl)
    {
        return UrlShortenerRepository.Get(shortUrl);
    }
}
