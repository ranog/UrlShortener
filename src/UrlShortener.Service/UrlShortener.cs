using System.Security.Cryptography;
using System.Text;

namespace UrlShortener.Service;

public class UrlShortener
{
    public string Shorten(string longUrl)
    {
        var hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(longUrl));
        var hexString = Convert.ToHexString(hashBytes).ToLower();
        return hexString[..7];
    }
}
