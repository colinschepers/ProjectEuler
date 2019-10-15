using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Euler38
    { 
        private dynamic Solve()
        {
            for (int i = 987654321; i >= 123456789; i--) 
            {
                if (Pandigital(i))
                { 
                    for (int prefixLength = 1; prefixLength < 5; prefixLength++)
                    {
                        int baseValue = i / (int)Math.Pow(10, 9 - prefixLength);
                        int remainder = i % (int)Math.Pow(10, 9 - prefixLength);

                        string remString = remainder.ToString();
                        for (int j = 2; j < 10 && remString.Length > 0; j++)
                        {
                            string prefix = (j * baseValue).ToString();

                            if (remString.StartsWith(prefix))
                                remString = remString.Substring(prefix.Length, remString.Length - prefix.Length);
                            else
                                break;
                        }

                        if (string.IsNullOrEmpty(remString))
                            return i;
                    } 
                }
            }

            return 0;
        }

        private bool Pandigital(int x)
        {
            const int allDigits = (1 << 9) - 1;

            int digits = 0;
            while (x > 0)
            {
                digits |= 1 << (int)(x % 10) - 1;

                //Console.WriteLine(Convert.ToString(digits, 2));

                if (digits == allDigits)
                    return true;

                x /= 10;
            }

            return false;
        }
    }
}
