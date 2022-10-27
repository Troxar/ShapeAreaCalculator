namespace ShapeAreaCalculatorLib;

  public abstract class Shape
{
    public abstract double Area { get; }

    public override string ToString() => GetType().Name;

    public static double GetArea(Shape shape) => shape.Area;
}
