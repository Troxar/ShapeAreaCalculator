namespace ShapeAreaCalculatorLib;

public class Circle : Shape
{
    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException(nameof(radius));
        }
        Radius = radius;
    }
    
    public double Radius { get; }

    public override double Area => Math.Round(Math.PI * Math.Pow(Radius, 2), Precision);
}