namespace ShapeAreaCalculatorLib;

public class Triangle : Shape
{
    public Triangle(double sideA, double sideB, double sideC)
    {
        CheckSide(sideA, nameof(sideA));
        CheckSide(sideB, nameof(sideB));
        CheckSide(sideC, nameof(sideC));
        CheckSides(sideA, sideB, sideC);

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    private void CheckSide(double side, string nameof)
    {
        if (side <= 0)
        {
            throw new ArgumentException(nameof);
        }
    }

    private void CheckSides(double sideA, double sideB, double sideC)
    {
        double[] sides = { sideA, sideB, sideC };
        Array.Sort(sides);

        if (sides[2] >= sides[0] + sides[1])
        {
            throw new ArgumentException("Triangle with such sides cannot exist");
        }
    }
    
    public double SideA { get; }
    
    public double SideB { get; }
    
    public double SideC { get; }

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