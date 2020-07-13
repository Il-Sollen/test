using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Exceptions
{
    /// <summary>
    /// Unknown operation in arithmetic expression
    /// </summary>
    public class UnknownOperationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownOperationException"/> exception without parameters
        /// </summary>
        public UnknownOperationException() : base()
        {         
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownOperationException"/> exception
        /// </summary>
        /// <param name="operation">Operation name</param>
        public UnknownOperationException(char operation) : base($"Unknown operation: {operation}")
        {
        }
    }
}
