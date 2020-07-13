using System;

namespace Calculator.Exceptions
{
    /// <summary>
    /// Violation of the rules of expression
    /// </summary>
    public class IncorrectExpressionException : Exception
    {
        //// <summary>
        /// Initializes a new instance of the <see cref="IncorrectExpressionException"/> exception
        /// </summary>
        public IncorrectExpressionException() : base($"Expression is incorrect")
        {
        }
    }
}
