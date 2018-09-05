using System;
using System.Collections.Generic;

namespace Common
{
    public class PrimeNumbers
    {
        public static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        public static HashSet<int> GetPrimeFactors(int compositeNumber)
        {
            if (IsPrime(compositeNumber))
            {
                return new HashSet<int>() { compositeNumber };
            }

            var factors = new HashSet<int>();
            var primeNumbers = GetPrimes(compositeNumber);

            while(compositeNumber > 1)
            {
                for (int i = 0; i < primeNumbers.Length; i++)
                {
                    if (compositeNumber % primeNumbers[i] == 0)
                    {
                        factors.Add(primeNumbers[i]);
                        compositeNumber /= primeNumbers[i];
                        i--;
                    }
                }
            }

            return factors;
        }

        public static int[] GetCompositeNumbers(int max)
        {
            int[] primesArray = new int[max + 1];
            const int Prime = 0;
            const int NotPrime = 1;

            for (int i = 2; i < max; i++)
            {
                if (primesArray[i] == NotPrime) continue;

                for (int j = 2 * i; j < max; j += i)
                {
                    primesArray[j] = NotPrime;
                }
            }

            var primes = new List<int>();

            for (int i = 2; i < max; i++)
            {
                if (primesArray[i] != Prime)
                {
                    primes.Add(i);
                }
            }

            return primes.ToArray();
        }

        public static HashSet<int> GetPrimeSet(int max)
        {
            int[] primesArray = new int[max + 1];
            const int Prime = 0;
            const int NotPrime = 1;

            for (int i = 2; i < max; i++)
            {
                if (primesArray[i] == NotPrime) continue;

                for (int j = 2 * i; j < max; j += i)
                {
                    primesArray[j] = NotPrime;
                }
            }

            var primes = new HashSet<int>();

            for (int i = 2; i < max; i++)
            {
                if (primesArray[i] == Prime)
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        public static int[] GetPrimes(int max)
        {
            int[] primesArray = new int[max + 1];
            const int Prime = 0;
            const int NotPrime = 1;

            for (int i = 2; i < max; i++)
            {
                if (primesArray[i] == NotPrime) continue;

                for (int j = 2 * i; j < max; j += i)
                {
                    primesArray[j] = NotPrime;
                }
            }

            var primes = new List<int>();

            for (int i = 2; i < max; i++)
            {
                if (primesArray[i] == Prime)
                {
                    primes.Add(i);
                }
            }

            return primes.ToArray(); ;
        }
    }
}
