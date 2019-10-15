using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Euler41
    {
        public dynamic Solve()
        {
            // n <= 7 because 1+2+3+4+5+6+7+8+9=45 and 1+2+3+4+5+6+7+8=36 so always dividable by 3
            for (ulong i = 7654321; i >= 0; i--)
            {
                if (MathTools.IsPrime(i) && NPandigital(i))
                {
                    //Console.WriteLine("Result: " + i);
                    return i;
                }
            }

            return 0;
        } 

        private bool NPandigital(ulong x)
        {
            int maxDigit = MathTools.DigitCount(x);

            int digits = 0;
            while (x > 0)
            {
                int digit = (int)(x % 10);

                if (digit == 0 || digit > maxDigit)
                    return false;

                int newDigits = digits | 1 << digit;

                //Console.WriteLine(Convert.ToString(newDigits, 2));

                if (newDigits == digits) // duplicated digit
                    return false;
                
                digits = newDigits;
                x /= 10;
            }

            return true;
        }
    }
}
