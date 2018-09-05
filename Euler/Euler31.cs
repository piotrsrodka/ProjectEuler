using System;
using System.Linq;

namespace Euler
{
    public class Euler31
    {
        private const int Goal = 200;

        public static void Start()
        {
            int count = 0;
            int[] coins = new int[] { 1, 2, 5, 10, 20, 50, 100, 200 };
            int[] coefficients = new int[8];

            while (IncrementCoefficients(coins, coefficients, 0))
            {
                if (Multiply(coins, coefficients) == Goal)
                {
                    count++;
                }
            }

            Console.WriteLine($"Count: {count}");
        }

        private static bool IncrementCoefficients(int[] coins, int[] coefficients, int i)
        {
            if (coefficients.Last() == 1)
            {
                return false;
            }

            if (Multiply(coins, coefficients) > Goal)
            {
                coefficients[i] = 0;
                return IncrementCoefficients(coins, coefficients, i + 1);
            }
            else
            {
                coefficients[i]++;
                return true;
            }
        }

        private static int Multiply(int[] a, int[] b)
        {
            int result = 0;

            for (int i = 0; i < a.Length; i++)
            {
                result += a[i] * b[i];
            }

            return result;
        }
    }
}
