namespace ShapeKit.Shapes;

public class Circle : Shape
{
    public float Radius { get; protected set; }

    public Circle(float radius) 
        => Radius = radius;

    public override void CalculateArea()
        => Area = (float)(Math.Pow(Radius, 2) * Math.PI);
}
