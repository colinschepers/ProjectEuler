using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class Euler46
    {
        /*  It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a prime and twice a square.

            9 = 7 + 2×12
            15 = 7 + 2×22
            21 = 3 + 2×32
            25 = 7 + 2×32
            27 = 19 + 2×22
            33 = 31 + 2×12

            It turns out that the conjecture was false.

            What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?
         */

        private List<uint> _primes = new List<uint>();

        public uint Solve()
        {
            for (uint cn = 9; cn < uint.MaxValue; cn += 2)
            {
                if (IsPrime(cn))
                    _primes.Add(cn);
                else if (!FormulaHolds(cn))
                    return cn;
            }
            return 0;
        }

        private bool FormulaHolds(uint cn)
        {
            foreach (var pr in _primes)
                if (Math.Sqrt((cn - pr) / 2) % 1 == 0) // Test for square
                    return true;
            return false;
        }

        private bool IsPrime(uint x)
        {
            foreach (var prime in _primes)
                if (x % prime == 0)
                    return false;
            return true;
        }
    }
}
