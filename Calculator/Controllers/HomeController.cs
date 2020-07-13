using Microsoft.AspNetCore.Mvc;
using Calculator.Services;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculatorService calculator;
        public HomeController(ICalculatorService calculator)
        {
            this.calculator = calculator;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(string expression) => View(this.calculator.Calculate(expression));
    }
}
