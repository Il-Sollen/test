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
            var matches = Regex.Match(expression, @"(\d+)([-+*\/]+|[-+*])(\d+)");

            var op = matches.Groups[2].Value;

            return op switch
            {
                "+" => double.Parse(matches.Groups[1].Value) + double.Parse(matches.Groups[3].Value),
                "-" => double.Parse(matches.Groups[1].Value) - double.Parse(matches.Groups[3].Value),
                "*" => double.Parse(matches.Groups[1].Value) * double.Parse(matches.Groups[3].Value),
                "/" => double.Parse(matches.Groups[1].Value) / double.Parse(matches.Groups[3].Value),
                _ => 0,
            };
        }
    }
}
