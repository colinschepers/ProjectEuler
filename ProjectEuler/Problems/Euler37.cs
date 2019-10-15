using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Euler37
    {
        public dynamic Solve()
        {
            uint count = 0;
            uint sum = 0;

            for (uint i = 10; i < 100000000 && count < 11; i++)
            {
                if (Truncatable(i))
                {
                    count++;
                    sum += i;
                    Console.WriteLine(i);
                }
            }

            return sum;
        }

        private bool Truncatable(uint x)
        {
            return TruncatableLeft(x) && TruncatableRight(x);
        }

        private bool TruncatableRight(ulong x)
        {
            if (!MathTools.IsPrime(x))
                return false;

            if (x < 10)
                return true;

            return TruncatableRight(x % (uint)(Math.Pow(10, DigitCount(x) - 1)));
        }

        private bool TruncatableLeft(ulong x)
        {
            if (!MathTools.IsPrime(x))
                return false;

            if (x < 10)
                return true;

            return TruncatableLeft(x / 10);
        }

        private byte DigitCount(ulong x)
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
