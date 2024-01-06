namespace UrlShortener.Application;

public class UrlRequest
{
    public string LongUrl { get; }

    public UrlRequest(string longUrl)
    {
        LongUrl = longUrl;
    }
}


