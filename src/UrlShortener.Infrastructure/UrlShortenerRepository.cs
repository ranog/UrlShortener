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
        return !Urls.ContainsKey(shortUrl) ? string.Empty : Urls[shortUrl];
    }
}
