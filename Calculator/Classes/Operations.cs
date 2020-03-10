using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Classes
{
    class Operations
    {
        public static decimal addition (decimal augend, decimal addend) =>  augend + addend;
        public static decimal subtraction(decimal minuend, decimal subtrahend) => minuend + subtrahend;
        public static decimal division(decimal dividend, decimal divisor) => dividend / divisor;
    }
}
