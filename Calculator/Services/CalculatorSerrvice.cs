using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Services
{
    public class CalculatorSerrvice : ICalculatorService
    {
        public double Calculate(string expression)
        {
            var rpn = ParseToRPN(expression);
            return CalculateRPNExpression(rpn);
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

        private static double CalculateRPNExpression(Queue<TokenBase> expression)
        {
            var tempStack = new Stack<double>();
            while (expression.Count != 0)
            {
                var token = expression.Dequeue();

                if (token is Number t)
                {
                    tempStack.Push(t.Value);
                }
                else
                {
                    var a = tempStack.Pop();
                    var b = tempStack.Pop();
                    tempStack.Push(token.Calc(b, a));
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
