using Calculator.Services;
using NUnit.Framework;
using System;

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
        [TestCaseSource("PrimitiveExpressionsSuccess")]
        public void PrimitiveExpressionCalculateSuccess(string expression, double expectedResult)
        {
            var actualResult = calculatorService.Calculate(expression);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCaseSource("UnlimitedOperandsExpressionsSuccess")]
        public void UnlimitedOperandsExpressionsCalculateSuccess(string expression, double expectedResult)
        {
            var actualResult = calculatorService.Calculate(expression);
            Assert.AreEqual(expectedResult, actualResult);
        }

        static object[] UnlimitedOperandsExpressionsSuccess =
        {
            new object[] { "7+9+6", 22 },
            new object[] { "38-20-9", 9 },
            new object[] { "8*3*7", 168 },
            new object[] { "102/2/5", 10.2 }
        };

        static object[] PrimitiveExpressionsSuccess =
        {
            new object[] { "2+3", 5 },
            new object[] { "6-3", 3 },
            new object[] { "5*4", 20 },
            new object[] { "21/7", 3 }
        };
    }
}