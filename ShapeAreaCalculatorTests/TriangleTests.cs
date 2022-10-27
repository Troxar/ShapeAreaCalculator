using FluentAssertions;
using ShapeAreaCalculatorLib;

namespace ShapeAreaCalculatorTests;

public class TriangleTests
{
    [Theory]
    [InlineData(2, 3, 4, 2.905)]
    [InlineData(3, 4, 5, 6)]
    [InlineData(13.2, 14.7, 21.9, 94.418)]
    public void Triangle_WhenPrecisionIsDefault_ShouldReturnCorrectArea(double sideA, double sideB, double sideC, double expected)
    {
        Triangle cut = new(sideA, sideB, sideC);

        cut.Area.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(2, 3, 4, 1, 2.9)]
    [InlineData(2, 3, 4, 2, 2.90)]
    [InlineData(2, 3, 4, 4, 2.9047)]
    [InlineData(2, 3, 4, 6, 2.904738)]
    public void Triangle_WhenPrecisionIsCustom_ShouldReturnCorrectArea(double sideA, double sideB, double sideC,
        int precision, double expected)
    {
        Triangle cut = new(sideA, sideB, sideC);
        cut.Precision = precision;

        cut.Area.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(4, 5, 3)]
    [InlineData(5, 3, 4)]
    public void Triangle_IsRightAngled(double sideA, double sideB, double sideC)
    {
        Triangle cut = new(sideA, sideB, sideC);
        
        cut.IsRightAngled().Should().BeTrue();
    }
    
    [Theory]
    [InlineData(1, 2, 2.9)]
    [InlineData(20, 15, 17)]
    public void Triangle_IsNotRightAngled(double sideA, double sideB, double sideC)
    {
        Triangle cut = new(sideA, sideB, sideC);
        
        cut.IsRightAngled().Should().BeFalse();
    }
    
    [Theory]
    [InlineData(2, 3, 3.605, 1, true)]
    [InlineData(2, 3, 3.605, 2, true)]
    [InlineData(2, 3, 3.605, 3, false)]
    [InlineData(2, 3, 3.605, 4, false)]
    public void Triangle_PrecisionAffectsIsRightAngled(double sideA, double sideB, double sideC,
        int precision, bool expected)
    {
        Triangle cut = new(sideA, sideB, sideC);
        cut.Precision = precision;
        
        cut.IsRightAngled().Should().Be(expected);
    }
    
    [Theory]
    [InlineData(-1, 1, 1)]
    [InlineData(1, 0, 1)]
    [InlineData(1, 0, -23.45)]
    public void Triangle_WhenSideIsLessThanOrEqualToZero_ShouldThrowException(double sideA, double sideB, double sideC)
    {
        FluentActions.Invoking(() => new Triangle(sideA, sideB, sideC))
            .Should().Throw<ArgumentException>();
    }
    
    [Theory]
    [InlineData(1, 2, 5)]
    [InlineData(9, 91, 2)]
    [InlineData(12.3, 4.5, 6.78)]
    public void Triangle_WhenSidesAreWrong_ShouldThrowException(double sideA, double sideB, double sideC)
    {
        FluentActions.Invoking(() => new Triangle(sideA, sideB, sideC))
            .Should().Throw<ArgumentException>();
    }
}