using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Euler34
    {
        private int[] factorials = new int[10];

        public Euler34()
        {
            factorials[0] = 1;
            for (int i = 1; i < factorials.Length; i++)
                factorials[i] = factorials[i - 1] * i; 
        }

        public dynamic Solve()
        {
            double totalSum = 0;

            for (int i = 10; i < 7 * factorials[9]; i++)
            {
                int sum = 0;

                int tmp = i;
                while (tmp > 0 && sum <= i) 
                {  
                    sum += factorials[tmp % 10];
                    tmp /= 10;
                } 

                if (sum == i)
                {
                    totalSum += sum;
                    Console.WriteLine(i);
                }
            }

            return totalSum;
        }
    }
}
