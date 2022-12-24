
using DoubleIntergral.App;
using Moq;
using Newtonsoft.Json.Linq;

namespace DoubleIntegral.Tests
{
    public class LegendrePolynomTests
    {

        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(1, 2, 2)]
        [InlineData(3, 0.5, -0.4375)]
        public void IsPolynomValueCorrect(int degree, double value, double expected)
        {
            // Arrange
            var legendrePolynom = new LegendrePolynom(degree);
            
            // Act
            var result = legendrePolynom.ComputePolynom(value);

            
            // Assert
            Assert.Equal(expected, result);   
        }

        [Theory]
        [InlineData(1, -1, 1, -1, 1, 0.0001, 0)]
        [InlineData(2, -1, 0, 1, -0.5, 0.0001, -0.577)]
        [InlineData(2, 0.1, 1, -0.485, 1, 0.0001, 0.577)]
        [InlineData(3, -1, -0.5,-1,  0.4375, 0.0001, -0.775)]
        [InlineData(3, 0.5, 1, - 0.6875, 1, 0.0001, 0.775)]
        public void IsRootFoundCorrectly(int degree, double a, double b, double aValue, double bValue, double eps, double expected)
        {
            // Arrange
            Mock<LegendrePolynom> mock = new Mock<LegendrePolynom>(degree);
            mock.Setup(r => r.ComputePolynom(a)).Returns(aValue);
            mock.Setup(r => r.ComputePolynom(b)).Returns(bValue);

            var legendrePolynom = new LegendrePolynom(degree);

            // Act
            var result = legendrePolynom.Dichotomy(a, b, eps);

            var result1 = Math.Round(result, 3);

            // Assert
            
            Assert.Equal(expected, result1);

        }


    }
}