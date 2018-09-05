using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Euler
{
    public class Euler30
    {
        public static void Start()
        {
            var numbers = new List<int>();

            for (int i = 2; i < 1000000; i++)
            {
                if (i == FifthPower(i))
                {
                    numbers.Add(i);
                }
            }
                        
            Trace.WriteLine($"Sum of the Numbers {numbers.Sum()}");
        }

        private static int FifthPower(int number)
        {
            double sum = 0;

            for (int i = 0; i < 6; i++)
            {
                int digit = number % 10;
                sum += Math.Pow(digit, 5);
                number /= 10;
            }

            return (int)sum;
        }        
    }
}
