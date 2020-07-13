namespace Calculator.Services
{
    /// <summary>
    /// Arithmetic expression calculation service
    /// </summary>
    public interface ICalculatorService
    {
        /// <summary>
        /// Calculate arithmetic expression
        /// </summary>
        /// <param name="expression">A. May contain basic arithmetic operations and priority signs (parentheses)</param>
        /// <returns>Result of arithmetic expression</returns>
        public float Calculate(string expression);
    }
}
