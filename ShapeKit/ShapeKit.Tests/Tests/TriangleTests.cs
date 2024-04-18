using ShapeKit.Models;
using ShapeKit.Shapes;

namespace ShapeKit.Tests.Tests
{
    public class TriangleTests
    {
        [Fact]
        public void CalculateArea_ReturnsCorrectArea()
        {
            // Arrange
            var sides = new List<ShapeSide>
            {
                new(3),
                new(4),
                new(5)
            };

            var triangle = new Triangle(sides);

            var halfPerimeter = sides.Sum(side => side.Length) / 2;
            var expectedArea = (float)Math.Sqrt(halfPerimeter *
                (halfPerimeter - sides[0].Length) *
                (halfPerimeter - sides[1].Length) *
                (halfPerimeter - sides[2].Length));

            // Act
            triangle.CalculateArea();

            // Assert
            Assert.Equal(expectedArea, triangle.Area);
        }

        [Fact]
        public void IsRightAngle_ReturnsCorrectIsRightAngle()
        {
            // Arrange
            var sides = new List<ShapeSide>
            {
                new(3),
                new(4),
                new(5)
            };

            var triangle = new Triangle(sides);

            var lenghtSides = sides.Select(side => side.Length).ToList();
            lenghtSides.Sort();

            bool expectedArea = false;
            if (Math.Pow(lenghtSides[2], 2) == Math.Pow(lenghtSides[1], 2) + Math.Pow(lenghtSides[0], 2))
            {
                expectedArea = true;
            }

            // Act
            // Assert
            Assert.Equal(expectedArea, triangle.IsRightAngle());
        }
    }
}
