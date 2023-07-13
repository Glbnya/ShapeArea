using ShapeArea.Factory;
using ShapeArea.Shapes;

namespace ShapeArea.Test
{
    public class UnitTest
    {
        /// <summary>
        /// Проверка на негативное/нулевое значение радиуса
        /// </summary>
        [Fact]
        public void NegativeRadiusCircleTest()
        {
            Assert.Throws<ArgumentException>(() => ShapeFactory.Create(-1));
            Assert.Throws<ArgumentException>(() => ShapeFactory.Create(0));
        }
        /// <summary>
        /// Проверка нахождения площади окружности
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="calculatedArea"></param>
        [Theory]
        [InlineData(7, 154)]
        [InlineData(44, 6079)]
        public void AreaCalculationCircleTest(double radius, double calculatedArea)
        {
            Assert.Equal(calculatedArea, Math.Round(ShapeFactory.Create(radius).GetArea()));
        }
        /// <summary>
        /// Проверка попытки добавить несуществующий треугольник
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        [Theory]
        [InlineData(-1, 1, 1)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 1, -1)]
        public void NegativeSideTriangleTest(double sideA, double sideB, double sideC)
        {
            Assert.Throws<ArgumentException>(() => ShapeFactory.Create(sideA, sideB, sideC));
        }
        /// <summary>
        /// Проверка попытки добавить несуществующий треугольник 
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        [Theory]
        [InlineData(3, 4, 17)]
        [InlineData(2, 1, 4)]
        [InlineData(5, 4, 0.5)]
        public void DoesNotExistTriangleTest(double sideA, double sideB, double sideC)
        {
            Assert.Throws<ArgumentException>(() => ShapeFactory.Create(sideA, sideB, sideC));
        }
        /// <summary>
        /// Проверка подсчета площади треугольника
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        /// <param name="expectedArea"></param>
        [Theory]
        [InlineData(3, 4, 5, 6)]
        [InlineData(20, 11, 10, 31.9756)]
        [InlineData(4, 4, 4, 6.9282)]
        public void AreaCalculationTriangleTest(double sideA, double sideB, double sideC, double expectedArea)
        {
            Assert.Equal(expectedArea, Math.Round(ShapeFactory.Create(sideA, sideB, sideC).GetArea(), 4));
        }
        /// <summary>
        /// Является ли прямоугольным треугольником, даже с учетом погрешности
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        /// <param name="expectedArea"></param>
        [Theory]
        [InlineData(3, 4, 5, true)]
        [InlineData(3.01, 4, 5, true)]
        public void IsRightTriangleTest(double sideA, double sideB, double sideC, bool expectedArea)
        {
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            Assert.True(expectedArea == triangle.IsRightTriangle());
        }
        /// <summary>
        /// Является ли прямоугольным треугольником, даже с учетом погрешности
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        /// <param name="expectedArea"></param>
        [Theory]
        [InlineData(3, 4, 50, true)]
        [InlineData(3.5, 4, 5, true)]
        public void IsNotRightTriangleTest(double sideA, double sideB, double sideC, bool expectedArea)
        {
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            Assert.False(expectedArea == triangle.IsRightTriangle());
        }
    }
}