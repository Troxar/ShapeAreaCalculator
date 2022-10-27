namespace ShapeAreaCalculatorLib;

public abstract class Shape
{
    private const int MAX_PRECISION = 15; 
    private int _precision = 3;
    public int Precision
    {
        get => _precision;
        set
        {
            if (value is < 0 or > MAX_PRECISION)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            _precision = value;
        }
    }

    public abstract double Area { get; }

    public override string ToString() => GetType().Name;

    public static double GetArea(Shape shape) => shape.Area;
}
