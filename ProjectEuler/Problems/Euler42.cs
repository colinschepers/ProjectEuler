using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectEuler
{
    public class Euler42
    {
        private HashSet<int> _triangleNumbers = new HashSet<int>();

        public dynamic Solve()
        {
            int tNr = 0;
            for (int i = 1; i < 100; tNr += i++)
                _triangleNumbers.Add(tNr);
              
            int nrTriangleWords = 0;
            var words = File.ReadAllText("Data/Euler42.txt").Split(',').Select(x => x.Replace("\"", ""));
            foreach (var word in words)
            {
                int sum = 0;
                foreach (var character in word)
                {
                    sum += (int)character - 64;
                }

                if (_triangleNumbers.Contains(sum))
                {
                    nrTriangleWords++;
                    //Console.WriteLine("Word: {0} \t\t Sum: {1}", word, sum);
                }
            }

            return nrTriangleWords;
        }
    }
}
