using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public interface ICalculatorService
    {
        public double Calculate(string expression);
    }
}
