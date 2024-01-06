namespace UrlShortener.Application;

public class UrlRequest
{
    public string ShortUrl { get; set; }
    public string LongUrl { get; set; }


    public UrlRequest(string longUrl, string shortUrl)
    {
        LongUrl = longUrl;
        ShortUrl = shortUrl;
    }
}


