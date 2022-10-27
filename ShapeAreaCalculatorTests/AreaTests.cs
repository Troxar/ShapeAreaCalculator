using System.Collections;
using FluentAssertions;
using ShapeAreaCalculatorLib;

namespace ShapeAreaCalculatorTests;

public class AreaTests
{
    [Theory]
    [ClassData(typeof(DataForTheoryGetAreaOfDifferentShapes))]
    public void Area_ShapeShouldReturnItsArea(Shape shape, double expected)
    {
        shape.Area.Should().Be(expected);
    }

    private class DataForTheoryGetAreaOfDifferentShapes : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Triangle(1, 1, 1),
                0.433
            };
            yield return new object[]
            {
                new Circle(2),
                12.566
            };
            yield return new object[]
            {
                new Square(3),
                9
            };
            yield return new object[]
            {
                new Rectangle(4, 5),
                20
            };
        }
    }
}

internal class Square : Shape
{
    internal Square(double length)
    {
        Side = length;
    }

    internal double Side { get; }

    public override double Area => Math.Pow(Side, 2);
}

internal class Rectangle : Shape
{
    internal Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    internal double Length { get; }

    internal double Width { get; }

    public override double Area => Length * Width;
}