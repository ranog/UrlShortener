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
        var isValidate = UrlValidator.Validate(validUrl);

        Assert.True(isValidate);
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
        var isValidate = UrlValidator.Validate(invalidUrl);

        Assert.False(isValidate);
    }
}
