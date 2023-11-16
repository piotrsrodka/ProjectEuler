using static Common.PrimeNumbers;

namespace Euler
{
    public class Euler47 : IEulerProblem
    {
        public void Start()
        {
            int i = 3;

            int tier = 4;

            var factorsCounts = new int[tier];

            while (true)
            {
                bool shouldContinue = false;

                for (int j = tier - 1; j >= 0; j--)
                {
                    if (IsPrime(i + j))
                    {
                        i += j + 1;
                        shouldContinue = true;
                        break;
                    }
                }

                if (shouldContinue) continue;

                for (int j = tier - 1; j >= 0; j--)
                {
                    var factors = GetPrimeFactors(i + j);

                    if (factors.Count != tier)
                    {
                        i += j + 1;
                        shouldContinue = true;
                        break;
                    }
                }

                if (shouldContinue) continue;

                Console.WriteLine("Got them!!: {0}", i);
                break;
            }
        }
    }
}
