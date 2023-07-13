using ShapeArea.Shapes.BaseShape;

namespace ShapeArea.Shapes
{
    public class Circle : AbstractShape
    {
        public Circle(double radius) => Radius = radius;
        private double Radius { get; }
        public override double GetArea() => Radius * Radius * 3.14;
    }
}
