using System.Security.Cryptography;
using System.Text;

namespace UrlShortener.Service;

public abstract class ShortenUrl
{
    public static string Shorten(string longUrl)
    {
        var hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(longUrl));
        var hexString = Convert.ToHexString(hashBytes).ToLower();
        return hexString[..7];
    }
}
