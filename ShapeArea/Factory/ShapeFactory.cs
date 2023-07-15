using ShapeArea.Shapes;
using ShapeArea.Shapes.BaseShape;

namespace ShapeArea.Factory
{
    /// <summary>
    /// Фабрика фигур
    /// Я вот так понял задание "Вычисление площади фигуры без знания типа фигуры в compile-time", можете написать, правильный ли это подход?
    /// </summary>
    public static class ShapeFactory
    {
        public static AbstractShape Create(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Радиус должен быть больше 0");

            return new Circle(radius);
        }

        public static Triangle Create(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentException("Сторона треугольника не может быть меньше или равна 0");

            if (sideA + sideB < sideC || sideA + sideC < sideB || sideB + sideC < sideA)
                throw new ArgumentException("Такого треугольника не существует");

            return new Triangle(sideA, sideB, sideC);
        }

    }
}
