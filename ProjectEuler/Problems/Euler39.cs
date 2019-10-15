using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Euler39
    {
        public dynamic Solve()
        {
            int max = 0;
            int best = 0;

            for (int p = 0; p <= 1000; p++)
            {
                int sum = 0;
                for (int a = 1; a < p * 1 / 3; a++)
                {
                    for (int b = a; b < p * 2 / 3; b++)
                    {
                        double c = Math.Sqrt(a * a + b * b);

                        if (c == p - a - b)
                        {
                            sum++;

                           // Console.WriteLine("{0} {1} {2}", a, b, c);
                        }
                    }
                }

                if (sum > max)
                {
                    max = sum;
                    best = p;
                }
            }

            //Console.WriteLine("Best: p = {0} with {1} solutions", best, max);

            return max;
        }
    }
}
