using Common;

namespace Euler
{
    public class Euler46 : IEulerProblem
    {
        public void Start()
        {
            int max = 10000;
            var composites = PrimeNumbers.GetCompositeNumbers(max);
            var primes = PrimeNumbers.GetPrimes(max);

            for (int c = 0; c < composites.Length; c++)
            {
                if (composites[c] % 2 == 0) continue;

                bool doable = false;

                for (int n = 1; n < Math.Sqrt(0.5 * composites[c]); n++)
                {
                    for (int p = 1; p < primes.Length && primes[p] <= composites[c] - 2 * n * n; p++)
                    {
                        if (composites[c] == primes[p] + 2 * n * n)
                        {
                            doable = true;
                            //Console.WriteLine($"{composites[c]} = {primes[p]} + 2 x {n}^2");
                        }

                        if (doable) break;
                    }

                    if (doable) break;
                }

                if (!doable)
                {
                    Console.WriteLine($"Not doable! {composites[c]}");
                    break;
                }
            }
        }
    }
}
