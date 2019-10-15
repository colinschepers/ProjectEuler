using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Euler33
    {
        public dynamic Solve()
        {
            int prodNum = 1;
            int prodDenom = 1;

            for (int i = 10; i < 99; i++)
            {
                for (int j = i + 1; j < 100; j++)
                {
                    double frac = (double)i / j;

                    double c1 = (i % 10);
                    double c2 = (int)(i / 10);
                    double c3 = (j % 10);
                    double c4 = (int)(j / 10);

                    if (frac == c1 / c3 && c2 == c4)
                    {
                        //Console.WriteLine("{0}/{1} = {2}/{3}", i, j, c1, c3);
                    }
                    else if (frac == c1 / c4 && c2 == c3)
                    {
                        prodNum *= i;
                        prodDenom *= j;
                        Console.WriteLine("{0}/{1} = {2}/{3}", i, j, c1, c4);
                    }
                    else if (frac == c2 / c3 && c1 == c4)
                    {
                        prodNum *= i;
                        prodDenom *= j;
                        Console.WriteLine("{0}/{1} = {2}/{3}", i, j, c2, c3);
                    }
                    else if (frac == c2 / c4 && c1 == c3)
                    {
                        //Console.WriteLine("{0}/{1} = {2}/{3}", i, j, c2, c4);
                    }
                }
            }

            Console.WriteLine("Frac Sum: {0}/{1}", prodNum, prodDenom);

            int gcd = MathTools.GCD(prodNum, prodDenom);
            Console.WriteLine("GCD: {0}", gcd);

            return prodDenom / gcd;
        }
    }
}
