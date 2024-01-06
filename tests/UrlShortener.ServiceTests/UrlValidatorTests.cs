using UrlShortener.Service;

namespace UrlShortener.ServiceTests;

public class UrlValidatorTests
{
    [Theory]
    [InlineData("https://www.example.com")]
    [InlineData("http://www.example.com")]
    [InlineData("ftp://www.example.com")]
    [InlineData("https://")]
    public void ValidateUrl_WhenPassingValidUrl_ItShouldReturnUrl(string validUrl)
    {
        var url = UrlValidator.Validate(validUrl);

        Assert.Equal(expected: validUrl, actual: url);
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
        var url = UrlValidator.Validate(invalidUrl);

        Assert.Equal(expected: "Invalid URL", actual: url);
    }
}
