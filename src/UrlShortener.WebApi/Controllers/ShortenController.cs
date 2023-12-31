using Microsoft.AspNetCore.Mvc;

using UrlShortener.Application;
using UrlShortener.Service;

namespace UrlShortener.WebApi.Controllers;

public class ShortenController
{
    [HttpPost]
    [Route("/v1/shorten")]
    public IActionResult Shorten([FromBody] UrlRequest request)
    {
        if(!request.Validate())
        {
            return new BadRequestObjectResult($"Url: {request.LongUrl} is not valid");
        }

        var shortUrl = Service.UrlShortener.Shorten(request.LongUrl);
        return new OkObjectResult(UrlHandler.AddUrls(request.LongUrl, shortUrl));

    }

    [HttpGet]
    [Route("/v1/{shortUrl}")]
    public string GetLongUrl(string shortUrl)
    {
        return UrlHandler.GetLongUrl(shortUrl);
    }
}

