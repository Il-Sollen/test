using Calculator.Services;
using NUnit.Framework;

namespace Calculator.UnitTests
{
    public class Tests
    {
        private ICalculatorService calculatorService;

        [SetUp]
        public void Setup()
        {
            calculatorService = new CalculatorSerrvice();
        }

        [Test]
        [TestCaseSource("PrimitiveExpressions")]
        public void PrimitiveExpressionSuccessCalculate(string expression, double expectedResult)
        {
            var actualResult = calculatorService.Calculate(expression);
            Assert.AreEqual(expectedResult, actualResult);
        }

        static object[] PrimitiveExpressions =
        {
            new object[] { "2+3", 5 },
            new object[] { "6-3", 3 },
            new object[] { "5*4", 20 },
            new object[] { "21/7", 3 }
        };
    }
}