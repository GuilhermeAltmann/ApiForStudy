using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestApiUdemy.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {

        private Dictionary<int, int> CacheFibo = new Dictionary<int, int>();

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {

                decimal sum = Convert(firstNumber) + Convert(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                decimal sub = Convert(firstNumber) - Convert(secondNumber);

                return Ok(sub.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                decimal div = Convert(firstNumber) / Convert(secondNumber);

                return Ok(div.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("mul/{firstNumber}/{secondNumber}")]
        public IActionResult Mul(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                decimal mul = Convert(firstNumber) * Convert(secondNumber);

                return Ok(mul.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("fibo/{number}")]
        public IActionResult Fibo(string number)
        {

            List<int> fibo = new List<int>();

            if (IsNumeric(number))
            {
                int numberConverted = Convert(number, "int");
                for (int i = 0; i < numberConverted; i++)
                {
                    fibo.Add(Fibonacci((i)));
                }
                return Ok(fibo);
            }

            return BadRequest("Invalid Input");
        }

        private dynamic Convert(string number, string type = "decimal")
        {
            decimal decimalValue;

            int intValue;

            if (type == "decimal")
            {

                if (decimal.TryParse(number, out decimalValue))
                {

                    return decimalValue;
                }
            }
            else {

                if (int.TryParse(number, out intValue))
                {

                    return intValue;
                }
            } 

            return 0;
        }

        private bool IsNumeric(string number)
        {
            double numberFormated;

            bool isNumber = double.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out numberFormated);

            return isNumber;
        }

        private int Fibonacci(int number)
        {

            int cache = GetCacheFibonacci(number);
            if (number < 2)
            {
                return number;
            } else if (cache != -1)
            {

                return cache;
            }
            else
            {
                int result = Fibonacci(number - 1) + Fibonacci(number - 2);

                CacheFibo.Add(number, result);
                return result;
            }
        }

        private int GetCacheFibonacci(int number)
        {
            try
            {

                return CacheFibo[number];
            }
            catch (KeyNotFoundException e) {

                return -1;
            }
        }
    }
}