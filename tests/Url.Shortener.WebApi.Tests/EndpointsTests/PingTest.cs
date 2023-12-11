namespace Url.Shortener.WebApi.Tests;

public class PingTest
{
    [Fact]
    public GetPingResponse_Should_Return_Pong()
    {
        // Arrange
        var ping = new Ping();
        
        // Act
        var response = ping.Get();
        
        // Assert
        response.Should().Be("Pong");
    }
}
