using Microsoft.AspNetCore.Mvc;

using UrlShortener.Application;
using UrlShortener.Service;

namespace UrlShortener.WebApi.Controllers;

public class ShortenController
{
    [HttpPost]
    [Route("/v1/shorten")]
    public string Shorten([FromBody] UrlRequest request)
    {
        var shortUrl = ShortenUrl.Shorten(request.LongUrl);
        return UrlHandler.AddUrls(request.LongUrl, shortUrl);
    }

    [HttpGet]
    [Route("/v1/{shortUrl}")]
    public string GetLongUrl(string shortUrl)
    {
        return UrlHandler.GetLongUrl(shortUrl);
    }
}

