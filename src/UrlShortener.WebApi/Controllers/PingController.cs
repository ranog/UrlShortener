using Microsoft.AspNetCore.Mvc;

namespace UrlShortener.WebApi.Controllers;

public class PingController
{
    [HttpGet]
    [Route("/v1/ping")]
    public string Root()
    {
        return "pong";
    }
}
