using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Euler35
    {
        public dynamic Solve()
        {
            int count = 0;

            foreach (var prime in MathTools.GetPrimes(1000000))
	        {
                var rotation = prime;
                while ((rotation = Rotate(rotation)) != prime)
                {
                    if (!MathTools.IsPrime(rotation))
                        break;
                }

                if (prime == rotation)
                {
                    //Console.WriteLine(prime);
                    count++;
                }
            }

            return count;
        }

        private uint Rotate(uint x)
        {
            uint lastDigit = x % 10; // read last digit
            x /= 10; // remove right digit
            x += lastDigit * (uint)(Math.Pow(10, DigitCount(x))); // put digit left
            return x;
        }

        private byte DigitCount(uint x)
        {
            byte nrDigits = 0;
            while (x > 0)
            {
                x /= 10;
                nrDigits++;
            }
            return nrDigits;
        }
    }
}
