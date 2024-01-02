using System.Net;
using System.Net.Http.Json;

using UrlShortener.Application;

namespace UrlShortener.WebApiTests.Controllers
{
    public class ShortenControllerTests
    {
        [Fact]
        public async Task Shorten_WhenPassingLongUrl_ItShouldReturnShort()
        {
            const string longUrl = "https://www.example.com";
            var shortUrl = ShortenUrl.Shorten(longUrl);

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(shortUrl)
            };

            // Criar uma classe derivada de HttpMessageHandler para substituição
            var messageHandler = new TestHttpMessageHandler(httpResponseMessage);

            var httpClient = new HttpClient(messageHandler);

            var response = await httpClient.PostAsJsonAsync("http://localhost:5230/v1/shorten", new UrlRequest(longUrl));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(shortUrl, await response.Content.ReadAsStringAsync());
        }
    }

    // Classe derivada de HttpMessageHandler para substituição
    public class TestHttpMessageHandler : HttpMessageHandler
    {
        private readonly HttpResponseMessage _response;

        public TestHttpMessageHandler(HttpResponseMessage response)
        {
            _response = response;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_response);
        }
    }
}

