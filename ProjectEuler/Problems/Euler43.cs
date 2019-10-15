using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Euler43
    {
        private int[] _divisors = new int[] { 2, 3, 5, 7, 11, 13, 17 };

        public dynamic Solve()
        {
            ulong sum = 0;

            foreach (var pandigital in GetPandigitals(10))
            {
                if (IsSpecial(pandigital))
                {
                    sum += pandigital;
                    //Console.WriteLine(pandigital);
                }
            }

            ////Slower method
            //var arr = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //while (Common.NextPermutation(arr))
            //{
            //    ulong pandigital = 0;
            //    for (int i = 0; i < arr.Length; i++)
            //        pandigital += (ulong)arr[i] * (ulong)Math.Pow(10, arr.Length - 1 - i);

            //    if (IsSpecial(pandigital))
            //    {
            //        sum += pandigital;
            //        Console.WriteLine(pandigital);
            //    }
            //}

            return sum;
        }
         
        private IEnumerable<ulong> GetPandigitals(int digitCount)
        {
            ulong min = (ulong)(Math.Pow(10, digitCount - 1) * 1);
            for (int i = 2; i < digitCount; i++)
                min += (ulong)(Math.Pow(10, digitCount - 1 - i) * i);

            ulong max = 0;
            for (int i = 1; i < digitCount; i++)
                max += (ulong)(Math.Pow(10, i) * i);

            ulong x = max;
            while (x >= min)
            {
                yield return x;

                // current digit in x
                int digit = (int)(x % 10);

                // mask for all encountered digits (iterative in for i loop)
                int digitMask = 1 << digit;

                // power 10 of current position
                ulong factor = 10;

                // find first position (from the right) which can be decreased
                for (int i = 1; i < digitCount; i++, factor *= 10)
                {
                    int oldDigit = digit;
                    digit = (int)(x / factor % 10);
                    digitMask |= 1 << digit; 

                    // check if digit can be decreased to a lower value (if a lower digit is encountered to its right)
                    if (digit > oldDigit)
                    {
                        // erase everything digit encountered from x
                        x = x / (factor * 10) * (factor * 10);

                        // find max digit encountered that is lower than current digit
                        var lowerDigit = digit - 1;
                        while (((1 << lowerDigit) & digitMask) == 0)
                            lowerDigit--;

                        // decrease to the max digit encountered to its right but lower than itself
                        x += factor * (ulong)lowerDigit;
                        digitMask -= 1 << lowerDigit;

                        // set to highest permutation of remaining digits to its right
                        factor = 1;
                        for (ulong d = 0; d < 10 && digitMask > 0; d++, digitMask >>= 1)
                        {
                            if ((digitMask & 1) != 0)
                            {
                                x += factor * d;
                                factor *= 10;
                            }
                        }

                        break;
                    }
                }
            }
        }

        private bool IsSpecial(ulong x)
        {
            for (int i = 6; i >= 0; i--)
            {
                uint triplet = (uint)((x / Math.Pow(10, 6 - i)) % 1000);

                if (triplet % _divisors[i] != 0)
                    return false;
            }

            return true;
        }
    }
}
