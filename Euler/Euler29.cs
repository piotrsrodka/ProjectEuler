using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Euler
{
    public class Euler29
    {
        public static void Start()
        {
            var list = new HashSet<double>();

            for (int a = 2; a <= 100; a++)
            {
                for (int b = 2; b <= 100; b++)
                {
                    list.Add(Math.Pow(a, b));
                }
            }

            Trace.WriteLine($"Distinct values count {list.Count()}");
        }
    }
}
