using Common;
using System.Diagnostics;

namespace Euler
{
    public class Euler27 : IEulerProblem
    {
        public void Start()
        {
            var primes = PrimeNumbers.GetPrimeSet(10000);
            int maxN = -1;
            int bMax = -99999;
            int aMax = -99999;

            for (int a = -999; a < 1000; a++)
            {
                for (int b = -1000; b <= 1000; b++)
                {
                    int n = 0;                    
                    var estimatedPrime = n * n + a * n + b;

                    while (primes.Contains(estimatedPrime))
                    {
                        n++;
                        estimatedPrime = n * n + a * n + b;
                    }

                    if (n > maxN)
                    {
                        maxN = n;
                        aMax = a;
                        bMax = b;
                    }
                }
            }

            Trace.WriteLine($"Max n = {maxN}, a = {aMax}, b = {bMax}");
        }
    }
}
