using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    public class MathTools
    {
        /// <summary>
        /// Gets the greatest common divisor; the largest positive integer that divides both of two integers.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GCD(int a, int b)
        {
            if (a < 0)
            {
                a = -a;
            }

            if (b < 0)
            {
                b = -b;
            }

            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        /// <summary>
        /// Gets the number of digits in a number.
        /// </summary>
        /// <param name="x">The number to count to digits for.</param>
        /// <returns>The number of digits in x.</returns>
        public static int DigitCount(ulong x)
        {
            if(x == 0)
            {
                return 0;
            }

            return (int)Math.Floor(Math.Log10(x) + 1);
        }

        /// <summary>
        // Takes the nth digit of a number.
        /// </summary>
        /// <param name="x">The number to take a digit from.</param>
        /// <param name="n">The digit to return, where n = 0 is the first digit on the left.</param>
        /// <returns>The nth digit of x, or -1 if out of bounds.</returns>
        public static sbyte NthDigit(ulong x, byte n)
        {
            var digitCount = DigitCount(x);

            if(n >= digitCount)
            {
                return -1;
            }

            double factor = Math.Pow(10, digitCount - n);
            return (sbyte)(x % factor / (factor / 10));
        }

        /// <summary>
        /// Gets a list of primes.
        /// </summary>
        /// <param name="n">The upper bound.</param>
        /// <returns>All primes from 1 to n.</returns>
        public static List<uint> GetPrimes(uint n)
        {
            var primes = new List<uint>();
            var sieve = new bool[n + 1];

            uint i = 2;
            while (i < sieve.Length)
            {
                primes.Add(i);

                if (i <= sieve.Length / 2)
                {
                    var multiple = i + i;
                    while (multiple < sieve.Length)
                    {
                        sieve[multiple] = true;
                        multiple += i;
                    }
                }

                while (++i < sieve.Length && sieve[i])
                {
                }
            }

            return primes;
        }

        /// <summary>
        /// Determines whether a number is a prime.
        /// </summary>
        /// <param name="x">The number to check.</param>
        /// <returns>Boolean whether x is a prime number.</returns>
        public static bool IsPrime(ulong x)
        {
            if (x == 2)
            {
                return true;
            }

            if (x < 2 || (x & 1) == 0)
            {
                return false;
            }

            for (ulong i = 3; (i * i) <= x; i += 2)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the next permutation of an array of integers.
        /// </summary>
        /// <param name="numList">The array of integers.</param>
        /// <returns>Whether the array was successfully set to a new permutation.</returns>
        public static bool NextPermutation(int[] numList)
        {
            /*
             Knuths
             1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
             2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
             3. Swap a[j] with a[l].
             4. Reverse the sequence from a[j + 1] up to and including the final element a[n].
             */

            var largestIndex = -1;
            for (var i = numList.Length - 2; i >= 0; i--)
            {
                if (numList[i] < numList[i + 1])
                {
                    largestIndex = i;
                    break;
                }
            }

            if (largestIndex < 0)
            {
                return false;
            }

            var largestIndex2 = -1;
            for (var i = numList.Length - 1; i >= 0; i--)
            {
                if (numList[largestIndex] < numList[i])
                {
                    largestIndex2 = i;
                    break;
                }
            }

            var tmp = numList[largestIndex];
            numList[largestIndex] = numList[largestIndex2];
            numList[largestIndex2] = tmp;

            for (int i = largestIndex + 1, j = numList.Length - 1; i < j; i++, j--)
            {
                tmp = numList[i];
                numList[i] = numList[j];
                numList[j] = tmp;
            }

            return true;
        }

        /// <summary>
        /// Gets the next permutation of an array of elements.
        /// </summary>
        /// <typeparam name="T">The generic type of the items in the array</typeparam>
        /// <param name="elements">The array of items.</param>
        /// <returns>Whether the array was successfully set to a new permutation.</returns>
        public static bool NextPermutation<T>(T[] elements) where T : IComparable<T>
        {
            var count = elements.Length;
            var done = true;

            for (var i = count - 1; i > 0; i--)
            {
                var curr = elements[i];

                if (curr.CompareTo(elements[i - 1]) < 0)
                {
                    continue;
                }

                done = false;

                var prev = elements[i - 1];

                var currIndex = i;

                for (var j = i + 1; j < count; j++)
                {
                    if (elements[j].CompareTo(curr) < 0 && elements[j].CompareTo(prev) > 0)
                    {
                        curr = elements[j];
                        currIndex = j;
                    }
                }

                elements[currIndex] = prev;
                elements[i - 1] = curr;

                for (var j = count - 1; j > i; j--, i++)
                {
                    var tmp = elements[j];
                    elements[j] = elements[i];
                    elements[i] = tmp;
                }

                break;
            }

            return !done;
        }
    }
}
