using ShapeKit.Shapes;

namespace ShapeKit.Tests.Tests;

public class CircleTests
{
    [Fact]
    public void CalculateArea_ReturnsCorrectArea()
    {
        // Arrange
        float expectedArea = (float)(Math.Pow(5, 2) * Math.PI);
        var circle = new Circle(5);

        // Act
        circle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, circle.Area);
    }
}
