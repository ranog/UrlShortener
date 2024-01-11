namespace UrlShortener.Infrastructure;

public class UrlShortenerRepository : IUrlShortenerRepository
{
    public static Dictionary<string, string> Urls { get; } = new();

    public void Add(string shortUrl, string longUrl)
    {
        if(!Urls.TryAdd(shortUrl, longUrl))
        {
            Urls[shortUrl] = longUrl;
        }
    }

    public string Get(string shortUrl) => Urls.TryGetValue(shortUrl, out var longUrl) ? longUrl : string.Empty;
}
