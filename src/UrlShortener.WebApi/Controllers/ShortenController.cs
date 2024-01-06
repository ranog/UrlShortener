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
        return ShortenUrl.Shorten(request.LongUrl);
    }
}

