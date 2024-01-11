using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Application;

public class UrlRequest
{
    public string LongUrl { get; set; }

    public UrlRequest(string longUrl)
    {
        LongUrl = longUrl;
    }

    public bool Validate() => !string.IsNullOrEmpty(LongUrl) && new UrlAttribute().IsValid(LongUrl);
}


