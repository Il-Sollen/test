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



        private static Queue<TokenBase> ParseToRPN(string input)
        {
            var outputQueue = new Queue<TokenBase>();
            var operationsStack = new Stack<TokenBase>();
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    var number = string.Empty;
                    while (char.IsDigit(input[i]))
                    {
                        number += input[i];
                        i++;

                        if (i == input.Length)
                            break;
                    }

                    outputQueue.Enqueue(new Number(number));
                    i--;
                }
                else
                {
                    var operation = ParseOperation(input[i]);

                    if (operation is OpenParenthesis)
                        operationsStack.Push(operation);

                    else if (operation is CloseParenthesis)
                    {
                        var stackOperstion = operationsStack.Pop();
                        while (!(stackOperstion is OpenParenthesis))
                        {
                            outputQueue.Enqueue(stackOperstion);
                            stackOperstion = operationsStack.Pop();
                        }
                    }
                    else
                    {
                        if (operationsStack.Count > 0)
                        {
                            if (operation.Weight <= operationsStack.Peek().Weight)
                                outputQueue.Enqueue(operationsStack.Pop());
                        }
                        operationsStack.Push(operation);
                    }
                }

            }
            while (operationsStack.Any())
                outputQueue.Enqueue(operationsStack.Pop());

            return outputQueue;
        }

        private static double CalculateRPNExpression(Queue<TokenBase> stack)
        {
            var tempStack = new Queue<double>();
            while (stack.Count != 0)
            {
                var token = stack.Dequeue();

                if (token is Number t)
                {
                    tempStack.Enqueue(t.Value);
                }
                else
                {
                    var a = tempStack.Dequeue();
                    var b = tempStack.Dequeue();
                    tempStack.Enqueue(token.Calc(a, b));
                }
            }

            return tempStack.Peek();
        }

        private static TokenBase ParseOperation(char operation) => operation switch
        {
            '+' => new Addition(),
            '-' => new Subtraction(),
            '*' => new Multiplication(),
            '/' => new Division(),
            '(' => new OpenParenthesis(),
            ')' => new CloseParenthesis(),
            _ => throw new Exception($"Unknown operation: {operation}"),
        };
    }
}
