using UrlShortener.WebApi.Controllers;

namespace UrlShortener.WebApiTests.Controllers;

public class PingControllerTests
{
    [Fact]
    public void Root_ReturnsPong()
    {
        var controller = new PingController();
        
        var result = controller.Root();
        
        Assert.Equal("pong", result);
    }
}
