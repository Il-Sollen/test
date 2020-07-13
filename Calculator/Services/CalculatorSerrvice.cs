using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public class CalculatorSerrvice : ICalculatorService
    {
        public double Calculate(string expression)
        {
            if (expression.Contains('+', StringComparison.InvariantCultureIgnoreCase))
            {
                var operands = expression.Split('+');
                return double.Parse(operands[0]) + double.Parse(operands[1]);
            }

            if (expression.Contains('-', StringComparison.InvariantCultureIgnoreCase))
            {
                var operands = expression.Split('-');
                return double.Parse(operands[0]) - double.Parse(operands[1]);
            }

            if (expression.Contains('*', StringComparison.InvariantCultureIgnoreCase))
            {
                var operands = expression.Split('*');
                return double.Parse(operands[0]) * double.Parse(operands[1]);
            }

            if (expression.Contains('/', StringComparison.InvariantCultureIgnoreCase))
            {
                var operands = expression.Split('/');
                return double.Parse(operands[0]) / double.Parse(operands[1]);
            }

            return 0;
        }
    }
}
