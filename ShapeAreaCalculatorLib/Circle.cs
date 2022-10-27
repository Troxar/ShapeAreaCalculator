namespace ShapeAreaCalculatorLib;

public class Circle : Shape
{
    public Circle(double radius)
    {
        Radius = radius;
    }
    
    public double Radius { get; }

    public override double Area => Math.Round(Math.PI * Math.Pow(Radius, 2), Precision);
}