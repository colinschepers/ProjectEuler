using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class Euler47
    {
        /*  The first two consecutive numbers to have two distinct prime factors are:

            14 = 2 × 7
            15 = 3 × 5

            The first three consecutive numbers to have three distinct prime factors are:

            644 = 2² × 7 × 23
            645 = 3 × 5 × 43
            646 = 2 × 17 × 19.

            Find the first four consecutive integers to have four distinct prime factors. What is the first of these numbers?
         */

        public uint Solve()
        {
            const uint factorCount = 4;
            const uint n = 1000000;
            byte count = 0;
            byte[] sieve = new byte[n];

            for (uint i = 2; i < n; i++)
            {
                if (sieve[i] == 0) // i is prime
                    for (uint j = i + i; j < n; j += i) // increase its multiples
                        sieve[j]++;

                if (sieve[i] < factorCount)
                    count = 0;
                else if (++count >= factorCount)
                    return i - factorCount + 1;
            }

            return 0;
        }
    }
}
