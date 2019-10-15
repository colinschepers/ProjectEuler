using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Euler44
    {
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
