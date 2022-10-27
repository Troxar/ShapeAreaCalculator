using FluentAssertions;
using ShapeAreaCalculatorLib;

namespace ShapeAreaCalculatorTests;

public class ShapeTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(-10)]
    public void Shape_WhenPrecisionIsNegative_ShouldThrowException(int precision)
    {
        SomeShape cut = new();
        
        cut.Invoking(x => x.Precision = precision)
            .Should().Throw<ArgumentOutOfRangeException>();
    }
    
    [Theory]
    [InlineData(16)]
    [InlineData(20)]
    public void Shape_WhenPrecisionIsGreaterThanMax_ShouldThrowException(int precision)
    {
        SomeShape cut = new();
        
        cut.Invoking(x => x.Precision = precision)
            .Should().Throw<ArgumentOutOfRangeException>();
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(7)]
    [InlineData(15)]
    public void Shape_WhenPrecisionIsCorrect_ShouldNotThrowException(int precision)
    {
        SomeShape cut = new();
        
        cut.Invoking(x => x.Precision = precision)
            .Should().NotThrow();
    }
}

internal class SomeShape : Shape
{
    public override double Area => 0;
}