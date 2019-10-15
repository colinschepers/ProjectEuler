using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    /*  The prime 41, can be written as the sum of six consecutive primes:
        41 = 2 + 3 + 5 + 7 + 11 + 13
        This is the longest sum of consecutive primes that adds to a prime below one-hundred.
        The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.
        Which prime, below one-million, can be written as the sum of the most consecutive primes? 
     */

    public class Euler50
    {
        private const int n = 1000000;
        private List<int> _primes = new List<int>();
        private bool[] _sieve = new bool[n];

        public int Solve()
        {
            // Sieve of Eratosthenes
            for (int i = 2; i < n; i++)
            {
                if (!_sieve[i])
                {
                    _primes.Add(i);

                    for (int j = i + i; j < n; j += i)
                        _sieve[j] = true;
                }
            }

            int sum = 0;
            int start = 0;
            int length = 0;

            // start at maximum span
            while (sum + _primes[start + length + 1] < n)
            {
                sum += _primes[length];
                length++;
            }

            while (length > 0)
            {
                if (!_sieve[sum])
                    return sum;

                int tempSum = sum;
                int tempStart = start;
                int tempLength = length;

                // shift left
                while (tempStart > 0)
                {
                    tempSum = tempSum - _primes[tempStart + tempLength - 1] + _primes[tempStart - 1];
                    tempStart--;

                    if (!_sieve[tempSum])
                        return tempSum;
                }

                sum -= _primes[start];
                start++;
                length--;

                //shift right once
                tempSum = sum - _primes[start] + _primes[start + length];
                if (tempSum < n)
                {
                    if (!_sieve[tempSum])
                        return tempSum;
                }
            }

            return 0;
        }
    }
}