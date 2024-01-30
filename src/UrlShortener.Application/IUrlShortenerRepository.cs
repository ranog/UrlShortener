namespace UrlShortener.Infrastructure;

public interface IUrlShortenerRepository
{
    void Add(string shortUrl, string longUrl);
    string Get(string shortUrl);
}
