using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Service;

public abstract class UrlValidator
{
    public static bool Validate(string? url)
    {
        return !string.IsNullOrEmpty(url) && new UrlAttribute().IsValid(url);
    }
}

