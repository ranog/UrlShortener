using UrlShortener.WebApi.Controllers;

namespace UrlShortener.WebApiTests.Controllers;

public class PingControllerTests
{
    [Fact]
    public void Root_ReturnsPong()
    {
        // Arrange
        var controller = new PingController();

        // Act
        var result = controller.Root();

        // Assert
        Assert.Equal("pong", result);
    }
}
