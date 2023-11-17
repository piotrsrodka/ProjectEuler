using System.Numerics;
using Common;

namespace Euler
{
    internal class Euler56 : IEulerProblem
    {
        public void Start()
        {
            long max = 0;

            for (int a = 2; a < 100; a++)
            {
                BigInteger number = a;

                for (int b = 2; b < 100; b++)
                {
                    number *= a;

                    long sum = Numbers.DigitsSum(number);

                    if (sum > max)
                    {
                        max = sum;
                        // Console.WriteLine($"{number} sum of the digits: {sum} for a = {a} and b = {b}");
                    }
                }
            }

            Console.WriteLine($"Max sum of number digits: {max}");
        }
    }
}
