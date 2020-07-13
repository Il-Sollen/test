using System;

namespace Calculator.Models
{
    /// <summary>
    /// Base abstract class for Tokens (arithmetic operations, priority signs, and figures)
    /// </summary>
    public abstract class TokenBase
    {
        /// <summary>
        /// Applies the arithmetic operation
        /// </summary>
        /// <param name="x">First argument</param>
        /// <param name="y">Second argument</param>
        /// <returns>Result of the arithmetic operation</returns>
        public abstract float Calc(float x, float y);

        /// <summary>
        /// Gets weight of the arithmetic operation
        /// </summary>
        public int Weight { get; protected set; }
    }

    /// <summary>
    /// Digit token
    /// </summary>
    public class Digit : TokenBase
    {
        /// <summary>
        /// Token digital value
        /// </summary>
        public float Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Digit"/> class.
        /// </summary>
        /// <param name="number"> Digital value </param>
        public Digit(string number)
        {
            if (string.IsNullOrEmpty(number) || !float.TryParse(number, out var _value))
            {
                throw new ArgumentException("The argument must be of type Single", nameof(number));
            }

            Value = _value;

            Weight = 3;
        }

        /// <summary>
        /// Not Implemented
        /// </summary>
        public override float Calc(float x, float y) => throw new NotImplementedException();
    }

    /// <summary>
    /// Addition operation token
    /// </summary>
    public class Addition : TokenBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Addition"/> class.
        /// </summary>
        public Addition()
        {
            Weight = 1;
        }

        /// <summary>
        /// Adds two numbers
        /// </summary>
        /// <param name="x">First argument</param>
        /// <param name="y">Second argument</param>
        /// <returns>The sum of two numbers</returns>
        public override float Calc(float x, float y) => x + y;
    }

    /// <summary>
    /// Subtraction operation token
    /// </summary>
    public class Subtraction : TokenBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Subtraction"/> class.
        /// </summary>
        public Subtraction()
        {
            Weight = 1;
        }

        /// <summary>
        /// Calculates the difference of two numbers
        /// </summary>
        /// <param name="x">First argument</param>
        /// <param name="y">Second argument</param>
        /// <returns>The difference of two numbers</returns>
        public override float Calc(float x, float y) => x - y;
    }

    /// <summary>
    /// Multiplication operation token
    /// </summary>
    public class Multiplication : TokenBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Multiplication"/> class.
        /// </summary>
        public Multiplication()
        {
            Weight = 2;
        }
        /// <summary>
        /// Multiplies two numbers
        /// </summary>
        /// <param name="x">First argument</param>
        /// <param name="y">Second argument</param>
        /// <returns>The product of two numbers</returns>
        public override float Calc(float x, float y) => x * y;
    }

    /// <summary>
    /// Division operation token
    /// </summary>
    public class Division : TokenBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Division"/> class.
        /// </summary>
        public Division()
        {
            Weight = 2;
        }
        /// <summary>
        /// Divides the first argument by the second
        /// </summary>
        /// <param name="x">First argument</param>
        /// <param name="y">Second argument</param>
        /// <returns>The quotient of two numbers</returns>
        public override float Calc(float x, float y)
        {
            if (y == 0)
                throw new DivideByZeroException();

            return x / y;
        }
    }

    /// <summary>
    /// Open parenthesis token
    /// </summary>
    public class OpenParenthesis : TokenBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenParenthesis"/> class.
        /// </summary>
        public OpenParenthesis()
        {
            Weight = 0;
        }

        /// <summary>
        /// Not Implemented
        /// </summary>
        public override float Calc(float x, float y) => throw new NotImplementedException();
    }

    /// <summary>
    /// Close parenthesis token
    /// </summary>
    public class CloseParenthesis : TokenBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloseParenthesis"/> class.
        /// </summary>
        public CloseParenthesis()
        {
            Weight = 0;
        }

        /// <summary>
        /// Not Implemented
        /// </summary>
        public override float Calc(float x, float y) => throw new NotImplementedException();
    }
}
