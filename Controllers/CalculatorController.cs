using System;
using CalculatorApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService<double> _calc;

        public CalculatorController(ICalculatorService<double> calc)
        {
            _calc = calc;
        }

        [HttpGet("add/{a}/{b}")]
        public ActionResult<double> Add(double a, double b) =>
            Ok(_calc.Add(a, b));

        [HttpGet("subtract/{a}/{b}")]
        public ActionResult<double> Subtract(double a, double b) =>
            Ok(_calc.Subtract(a, b));

        [HttpGet("multiply/{a}/{b}")]
        public ActionResult<double> Multiply(double a, double b) =>
            Ok(_calc.Multiply(a, b));

        [HttpGet("divide/{a}/{b}")]
        public ActionResult<double> Divide(double a, double b)
        {
            try
            {
                return Ok(_calc.Divide(a, b));
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
