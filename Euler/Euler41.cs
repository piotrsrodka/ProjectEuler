using Common;
using System;
using System.Linq;

namespace Euler
{
    public class Euler41 : IEulerProblem
    {
        public void Start()
        {
            var primes = PrimeNumbers.GetPrimeSet(10000000);

            foreach (var prime in primes.OrderByDescending(z => z))
            {
                var digits = Numbers.ToDigits(prime);
                Array.Sort(digits);

                bool isPandigital = true;

                for (int i = 0; i < digits.Length; i++)
                {
                    if (i + 1 != digits[i])
                    {
                        isPandigital = false;
                        break;
                    }
                }                

                if (isPandigital)
                {
                    Console.WriteLine($"Highest pandigital prime is {prime}");
                    break;
                }
            }
        }
    }
}
