using System;

namespace Calculator.Models
{
    public abstract class TokenBase
    {
        public abstract double Calc(double x, double y);

        public int Weight { get; protected set; }
    }

    public class Number : TokenBase
    {
        public double Value { get; private set; }
        public Number(string number)
        {
            if (string.IsNullOrEmpty(number) || !Double.TryParse(number, out var _value))
            {
                throw new ArgumentException("The argument must be of type double", nameof(number));
            }

            Value = _value;

            Weight = 3;
        }

        public override double Calc(double x, double y) => throw new NotImplementedException();
    }

    public class Addition : TokenBase
    {
        public Addition()
        {
            Weight = 1;
        }
        public override double Calc(double x, double y) => x + y;
    }

    public class Subtraction : TokenBase
    {
        public Subtraction()
        {
            Weight = 1;
        }
        public override double Calc(double x, double y) => x - y;
    }

    public class Multiplication : TokenBase
    {
        public Multiplication()
        {
            Weight = 2;
        }
        public override double Calc(double x, double y) => x * y;
    }

    public class Division : TokenBase
    {
        public Division()
        {
            Weight = 2;
        }
        public override double Calc(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException();

            return x / y;
        }
    }

    public class OpenParenthesis : TokenBase
    {
        public OpenParenthesis()
        {
            Weight = 0;
        }
        public override double Calc(double x, double y) => throw new NotImplementedException();
    }

    public class CloseParenthesis : TokenBase
    {
        public CloseParenthesis()
        {
            Weight = 0;
        }
        public override double Calc(double x, double y) => throw new NotImplementedException();
    }
}
