namespace ShapeAreaCalculatorLib;

public class Triangle : Shape
{
    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public double SideA { get; }
    
    public double SideB { get; }
    
    public double SideC { get; }

    private int _precision = 3;
    public int Precision
    {
        get => _precision;
        set
        {
            if (value is < 0 or > 15)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            _precision = value;
        }
    }

    public override double Area
    {
        get
        {
            double p = (SideA + SideB + SideC) / 2;
            double s = Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
            return Math.Round(s, Precision);
        }
  } 

    public bool IsRightAngled()
    {
        double[] sides = { SideA, SideB, SideC };
        Array.Sort(sides);
        double diff = Math.Pow(sides[2], 2) - (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2));
        double tolerance = Math.Pow(10, -Precision);
        
        return Math.Abs(diff) < tolerance;   
    }
}