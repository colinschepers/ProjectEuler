using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    /*  The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: 
            (i) each of the three terms are prime, and, 
            (ii) each of the 4-digit numbers are permutations of one another.
        There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, 
            exhibiting this property, but there is one other 4-digit increasing sequence.
        What 12-digit number do you form by concatenating the three terms in this sequence?
    */

    public class Euler49
    {
        public ulong Solve()
        {
            const int n = 10000;
            List<int> primes = new List<int>();
            bool[] divisable = new bool[n]; // Sieve of Eratosthenes
            for (int i = 2; i < n; i++)
            {
                if (!divisable[i])
                {
                    if (i >= 1000 && i != 1487 && i != 4817 && i != 8147)
                        primes.Add(i);

                    for (int j = i + i; j < n; j += i) // tag its multiples
                        divisable[j] = true;
                }
            }

            const int increment = 3330;
            foreach (var p1 in primes)
	        {
                int p2 = p1 + increment;
                int p3 = p2 + increment;
                if(!divisable[p2] && !divisable[p3] && DigitMask(p1) == DigitMask(p2) && DigitMask(p2) == DigitMask(p3))
                    return (ulong)p1 * 100000000 + (ulong)p2 * 10000 + (ulong)p3; 
            }

            return 0;
        }

        private int DigitMask(int x)
        {
            int mask = 0;
            while (x > 0)
            {
                mask |= 1 << x % 10;
                x /= 10;
            }
            return mask;
        }
    }
}
