using System;

namespace Calculator.Exceptions
{
    public class IncorrectExpressionException : Exception
    {
        public IncorrectExpressionException() : base()
        {
        }

        public IncorrectExpressionException(char operation) : base($"Expression is incorrect")
        {
        }
    }
}
