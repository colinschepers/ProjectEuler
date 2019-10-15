using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Euler50 euler = new Euler50();

            Stopwatch sw = Stopwatch.StartNew();
            var solution = euler.Solve();
            sw.Stop();

            Console.WriteLine("Solution: {0}", solution);
            Console.WriteLine("Running time: {0}", sw.Elapsed);
            Console.ReadLine();
        }
    }
}
