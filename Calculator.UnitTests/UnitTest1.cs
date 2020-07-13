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
        [TestCaseSource("ExpressionsSuccess")]
        public void ExpressionCalculate_Success(string expression, double expectedResult)
        {
            var actualResult = calculatorService.Calculate(expression);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("3/0")]
        [TestCase("4/(3-3)")]
        public void ExpressionCalculate_DivideByZeroException(string expression)
        {
            Assert.Catch<DivideByZeroException>(() => calculatorService.Calculate(expression));  
        }

        static object[] ExpressionsSuccess =
        {
            new object[] { "2+3", 5 },
            new object[] { "6-3", 3 },
            new object[] { "5*4", 20 },
            new object[] { "21/7", 3 },
            new object[] { "7+9+6", 22 },
            new object[] { "1+2+3+4+5+6+7+8+9", 45 },
            new object[] { "38-20-9", 9 },
            new object[] { "8*3*7", 168 },
            new object[] { "102/2/5", 10.2 },
            new object[] { "3+9-6", 6 },
            new object[] { "7+5*3", 22 },
            new object[] { "7*(5+9)+9", 107 },
            new object[] { "(5+6)/(7+9)*8", 5.5 }
        };
    }
}