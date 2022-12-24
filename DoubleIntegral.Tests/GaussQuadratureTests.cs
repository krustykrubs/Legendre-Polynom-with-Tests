

using DoubleIntergral.App;
using Moq;
using Newtonsoft.Json.Linq;

namespace DoubleIntegral.Tests
{
    public class GaussQuadratureTests
    {
        [Theory]
        [InlineData(0, 2)]
        [InlineData(1, 0)]
        [InlineData(3, 0)]
        public void IsCoefficientCorrect(int degree, double expected)
        {
            // Arrange
            Mock<LegendrePolynom> mock = new Mock<LegendrePolynom>(degree);

            var gaussQuadrature = new GaussQuadrature(mock.Object);

            // Act
            var result = gaussQuadrature.GetCoefficient(degree);

            // Assert
            Assert.Equal(expected, result);
        }

         [Fact]
          public void IsSlaeCorrect()
          {
              // Arrange
              double[] coefficients = new double []{ -0.775, 0, 0.775 };
              double[] expected = new double[] { 0.555, 0.888, 0.555 };

              Mock<LegendrePolynom> mock = new Mock<LegendrePolynom>(3);
              var gaussQuadrature = new GaussQuadrature(mock.Object);

              Mock<GaussQuadrature> mock2 = new Mock<GaussQuadrature>(mock.Object);

              mock2.Setup(r => r.GetCoefficient(0)).Returns(2);
              mock2.Setup(r => r.GetCoefficient(1)).Returns(0);
              mock2.Setup(r => r.GetCoefficient(2)).Returns(0.667);

              // Act
              var result = gaussQuadrature.ComputeSlae(coefficients);


              // Assert
              foreach (int i in result)
              {
                  Assert.Equal(expected[i], Math.Round(result[i], 3));

              }

          } 
       
       /* [Fact]
        public void IsSlaeCorrect()
        {
            // Arrange
            double[] expected = new double[] { 0.555, 0.888, 0.555 };
            
            Mock<LegendrePolynom> mock = new Mock<LegendrePolynom>(2);
            var gaussQuadrature = new GaussQuadrature(mock.Object);

            Mock<GaussQuadrature> mock2 = new Mock<GaussQuadrature>(mock.Object);

            mock2.Setup(r => r.GetCoefficient(0)).Returns(2);
            mock2.Setup(r => r.GetCoefficient(1)).Returns(0);
            mock2.Setup(r => r.GetCoefficient(2)).Returns(0.667);


            // Act 
            var result = gaussQuadrature.ComputeSlae();

            // Assert
            foreach (int i in result)
            {
                Assert.Equal(expected[i], Math.Round(result[i], 3));

            }

        }*/

    }
}
