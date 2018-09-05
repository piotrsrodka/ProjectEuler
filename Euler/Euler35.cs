using System.Collections.Generic;
using Common;
using System;

namespace Euler
{
    public class Euler35
    {
        public static void Start()
        {
            var circularPrimes = new List<int>();
            var primes = PrimeNumbers.GetPrimeSet(1000000);

            foreach (var prime in primes)
            {
                var digits = Numbers.ToDigits(prime);

                bool isCircular = true;

                for (int i = 1; i < digits.Length; i++)
                {
                    if (!primes.Contains(Rotate(digits)))
                    {
                        isCircular = false;
                    }
                }

                if (isCircular)
                {
                    circularPrimes.Add(prime);
                }
            }

            Console.WriteLine($"Number of circular primes below one million: {circularPrimes.Count}");
        }

        private static int Rotate(int[] digits)
        {
            int first = digits[0];

            for (int i = 0; i < digits.Length - 1; i++)
            {
                digits[i] = digits[i + 1];
            }

            digits[digits.Length - 1] = first;

            return Numbers.ToNumber(digits);
        }
    }
}
