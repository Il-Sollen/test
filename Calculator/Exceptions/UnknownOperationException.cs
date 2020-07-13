using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Exceptions
{
    public class UnknownOperationException: Exception
    {
        public UnknownOperationException() : base()
        {         
        }

        public UnknownOperationException(char operation) : base($"Unknown operation: {operation}")
        {
        }
    }
}
