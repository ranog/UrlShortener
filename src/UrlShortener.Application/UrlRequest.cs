namespace UrlShortener.Application;

public class UrlRequest
{
    public string LongUrl { get; set; }

    public UrlRequest(string longUrl)
    {
        LongUrl = longUrl;
    }
}
