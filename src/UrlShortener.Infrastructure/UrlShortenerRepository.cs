namespace UrlShortener.Infrastructure;

public static class UrlShortenerRepository
{
    public static Dictionary<string, string> Urls { get; } = new();

    public static void Add(string shortUrl, string longUrl)
    {
        if(!Urls.TryAdd(shortUrl, longUrl))
        {
            Urls[shortUrl] = longUrl;
        }
    }

    public static string Get(string shortUrl)
    {
        return Urls.TryGetValue(shortUrl, out var longUrl) ? longUrl : string.Empty;
    }
}
