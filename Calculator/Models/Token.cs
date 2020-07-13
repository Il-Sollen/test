using System;

namespace Calculator.Models
{
    public abstract class TokenBase
    {
        public abstract float Calc(float x, float y);

        public int Weight { get; protected set; }
    }

    public class Number : TokenBase
    {
        public float Value { get; private set; }
        public Number(string number)
        {
            if (string.IsNullOrEmpty(number) || !float.TryParse(number, out var _value))
            {
                throw new ArgumentException("The argument must be of type Single", nameof(number));
            }

            Value = _value;

            Weight = 3;
        }

        public override float Calc(float x, float y) => throw new NotImplementedException();
    }

    public class Addition : TokenBase
    {
        public Addition()
        {
            Weight = 1;
        }
        public override float Calc(float x, float y) => x + y;
    }

    public class Subtraction : TokenBase
    {
        public Subtraction()
        {
            Weight = 1;
        }
        public override float Calc(float x, float y) => x - y;
    }

    public class Multiplication : TokenBase
    {
        public Multiplication()
        {
            Weight = 2;
        }
        public override float Calc(float x, float y) => x * y;
    }

    public class Division : TokenBase
    {
        public Division()
        {
            Weight = 2;
        }
        public override float Calc(float x, float y)
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
        public override float Calc(float x, float y) => throw new NotImplementedException();
    }

    public class CloseParenthesis : TokenBase
    {
        public CloseParenthesis()
        {
            Weight = 0;
        }
        public override float Calc(float x, float y) => throw new NotImplementedException();
    }
}
