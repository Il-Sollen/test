using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public class CalculatorSerrvice : ICalculatorService
    {
        public double Calculate(string expression)
        {
            var operation = Regex.Match(expression, @"[-+*\/]").Value;

            var operands = expression.Split(operation);

            return operation switch
            {
                "+" => Addition(operands),
                "-" => Subtraction(operands),
                "*" => Multiplication(operands),
                "/" => Division(operands),
                _ => 0,
            };
        }

        private static double Addition(string[] operands) => operands.Sum(op => double.Parse(op));

        private static double Subtraction(string[] operands)
        {
            double result = double.Parse(operands[0]);
            for (int i = 1; i < operands.Length; i++)
            {
                result -= double.Parse(operands[i]);
            }

            return result;
        }

        private static double Multiplication(string[] operands)
        {
            double result = double.Parse(operands[0]);
            for (int i = 1; i < operands.Length; i++)
            {
                result *= double.Parse(operands[i]);
            }

            return result;
        }

        private static double Division(string[] operands)
        {
            double result = double.Parse(operands[0]);
            for (int i = 1; i < operands.Length; i++)
            {
                result /= double.Parse(operands[i]);
            }

            return result;
        }
    }
}
