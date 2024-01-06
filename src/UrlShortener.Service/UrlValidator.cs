using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Service;

public abstract class UrlValidator
{
    public static string Validate(string? url)
    {
        return url is not null && new UrlAttribute().IsValid(url) ? url : "Invalid URL";
    }
}

