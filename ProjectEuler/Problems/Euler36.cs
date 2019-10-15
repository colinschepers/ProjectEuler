using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Euler36
    {
        public dynamic Solve()
        {
            uint sum = 0;

            for (uint i = 0; i < 1000000; i++)
            {
                string base10 = i.ToString();
                if (Palindrome(base10))
                {
                    string base2 = Convert.ToString(i, 2);
                    if (Palindrome(base2))
                    {
                        Console.WriteLine(base10 + " " + base2);
                        sum += i;
                    }
                }
            }

            return sum;
        }


        private bool Palindrome(string value)
        {
            if (value.Length <= 1)
                return true;

            if (value[0] == value[value.Length - 1])
                return Palindrome(value.Substring(1, value.Length - 2));

            return false;
        }
    }
}
