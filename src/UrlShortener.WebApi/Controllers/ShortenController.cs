using Microsoft.AspNetCore.Mvc;

using UrlShortener.Application;
using UrlShortener.Infrastructure;
using UrlShortener.Service;

namespace UrlShortener.WebApi.Controllers;

[Route("api/v1")]
public class ShortenController : ControllerBase
{
    private readonly UrlHandler _urlHandler = new(urlShortenerRepository: new UrlShortenerRepository(), urlShortener: new Service.UrlShortener());

    [HttpPost("data/shorten")]
    public IActionResult Shorten([FromBody] UrlRequest request)
    {
        if(!request.Validate())
        {
            return new BadRequestObjectResult($"Url: {request.LongUrl} is not valid");
        }

        return new OkObjectResult(_urlHandler.AddUrl(request));
    }

    [HttpGet("{shortUrl}")]
    public IActionResult GetLongUrl([FromRoute] string shortUrl) => RedirectPermanent(_urlHandler.GetLongUrl(shortUrl));
}
