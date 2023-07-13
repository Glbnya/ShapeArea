using ShapeArea.Shapes.BaseShape;
namespace ShapeArea.Shapes
{
    public class Triangle : AbstractShape
    {
        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        private double SideA { get; }
        private double SideB { get; }
        private double SideC { get; }

        public override double GetArea()
        {
            double semiP = (SideA + SideB + SideC) / 2;

            return Math.Sqrt(semiP * (semiP - SideA) * (semiP - SideB) * (semiP - SideC));
        }
        /// <summary>
        /// Проверка, является ли треугольник прямоугольным
        /// </summary>
        /// <returns></returns>
        public bool IsRightTriangle()
        {
            List<double> sides = new() { SideA, SideB, SideC };

            double longestSide = sides.Max();

            sides.Remove(longestSide);

            var errorMargin = Math.Abs(longestSide * longestSide) * .01; // величина допустимой погрешности

            if (Math.Abs(sides[0] * sides[0] + sides[1] * sides[1] - longestSide * longestSide) <= errorMargin)
                return true;

            return false;
        }
    }
}
