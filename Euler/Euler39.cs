using System;

namespace Euler
{
    public class Euler39
    {
        public void Start()
        {
            var solutions = new int[1001];

            for (int a = 1; a < 999; a++)
            {
                for (int b = a; b < 999 - a; b++)
                {
                    double preciseC = Math.Sqrt(a * a + b * b);
                    int c = (int)preciseC;

                    if (preciseC > c) continue;

                    var p = a + b + c;

                    if (p > 1000) break;

                    solutions[p]++;
                }
            }

            int max = 0;
            int index = 0;

            for (int i = 1; i < solutions.Length; i++)
            {
                if (solutions[i] > max)
                {
                    max = solutions[i];
                    index = i;
                }
            }

            Console.WriteLine($"Perimeter maximizing solutions: {index}");
        }
    }
}
