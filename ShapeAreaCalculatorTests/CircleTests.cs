using FluentAssertions;
using ShapeAreaCalculatorLib;

namespace ShapeAreaCalculatorTests;

public class CircleTests
{
    [Theory]
    [InlineData(1, 3.142)]
    [InlineData(18, 1017.876)]
    [InlineData(6.2, 120.763)]
    public void Triangle_WhenPrecisionIsDefault_ShouldReturnCorrectArea(double radius, double expected)
    {
        Circle cut = new(radius);

        cut.Area.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(6.2, 0, 121)]
    [InlineData(6.2, 1, 120.8)]
    [InlineData(6.2, 2, 120.76)]
    [InlineData(6.2, 3, 120.763)]
    [InlineData(6.2, 4, 120.7628)]
    public void Triangle_WhenPrecisionIsCustom_ShouldReturnCorrectArea(double radius, int precision, double expected)
    {
        Circle cut = new(radius);
        cut.Precision = precision;
    
        cut.Area.Should().Be(expected);
    }
}