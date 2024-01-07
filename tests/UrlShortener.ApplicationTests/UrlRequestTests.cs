using UrlShortener.Application;

namespace UrlShortener.ApplicationTests;

public class UrlRequestTests
{
    private readonly UrlRequest _request = new("https://www.example.com");

    [Theory]
    [InlineData("https://www.example.com")]
    [InlineData("http://www.example.com")]
    [InlineData("ftp://www.example.com")]
    [InlineData("https://")]
    public void ValidateUrl_WhenPassingValidUrl_ItShouldReturnUrl(string validUrl)
    {
        _request.LongUrl = validUrl;

        Assert.True(_request.Validate());
    }

    [Theory]
    [InlineData("www.example.com")]
    [InlineData("example.com")]
    [InlineData("example")]
    [InlineData(" ")]
    [InlineData(null)]
    [InlineData("https:")]
    public void ValidateUrl_WhenPassingInvalidUrl_ItShouldReturnAnErrorMessage(string invalidUrl)
    {
        _request.LongUrl = invalidUrl;

        Assert.False(_request.Validate());
    }
}
