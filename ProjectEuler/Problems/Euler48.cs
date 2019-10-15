using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class Euler48
    {
        /*  The series, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317.
            Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000.
         */

        public ulong Solve()
        {
            const uint n = 1000;
            const ulong mod = 10000000000; // only interested in last 10 digits

            ulong sum = 0;
            for (uint i = 1; i <= n; i++)
                sum += Power(i, mod);

            return sum % mod;
        }

        private ulong Power(uint x, ulong mod)
        {
            ulong pow = x;
            for (int i = 1; i < x; i++)
                pow = (pow * x) % mod;
            return pow;
        }
    }
}
