using Common;

namespace Euler
{
    public class Euler50 : IEulerProblem
    {
        public void Start()
        {
            int max = 1000000;
            var primeSet = PrimeNumbers.GetPrimeSet(max);
            var primeArray = PrimeNumbers.GetPrimes(max);
            int maxWidth = 500;

            for (int from = 0; from < primeArray.Length; from++)
            {
                for (int width = maxWidth; width < 800; width++)
                {
                    if (from + width > primeArray.Length) break;

                    int number = 0;

                    for (int i = from; i < from + width; i++)
                    {
                        number += primeArray[i];
                    }

                    if (number > 1000000) break;

                    if (primeSet.Contains(number) && width > maxWidth)
                    {
                        maxWidth = width;
                        Console.WriteLine($"Number {number}, terms {width}");
                    }
                }
            }
        }
    }
}
