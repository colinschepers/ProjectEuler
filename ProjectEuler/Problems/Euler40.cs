using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Euler40
    {
        public dynamic Solve()
        {
            int digitCount = 0;
            int digitCountMod = 1;

            int n = 1;
            int nMod = 1;

            int prod = 1;
             
            for (int i = 1; i < 1000000; i++, n+= digitCount)
            {
                // increase digit count every power of 10
                if (i % digitCountMod == 0)
                {
                    digitCount++;
                    digitCountMod *= 10;
                }

                int delta = (n + digitCount - 1) % nMod;
                if (delta < digitCount)
                {
                    int digit = i / (int)Math.Pow(10, delta) % 10;

                    nMod *= 10;
                    prod *= digit;

                    //Console.WriteLine("d{0} = {1}{2} | digit = {3}", 
                    //    n, 
                    //    Common.NthDigit((ulong)i, 0),
                    //    delta > 0 ? string.Format("({0})", i % (int)Math.Pow(10, digitCount - 1)) : string.Empty, 
                    //    digit);
                } 
            }

            return prod;
        }
    }
}
