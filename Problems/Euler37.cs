using Common;

namespace Euler
{
    public class Euler37
    {
        const int Max = 11;

        public void Start()
        {
            var primes = PrimeNumbers.GetPrimeSet(1000000);
            var truncatablePrimes = new List<int>();

            foreach (var prime in primes.Skip(4))
            {
                var digits = Numbers.ToDigits(prime);
                var lefts = new HashSet<int>();
                var rights = new HashSet<int>();

                for (int i = 1; i < digits.Length; i++)
                {
                    lefts.Add(Numbers.ToNumber(digits, i, digits.Length));
                    rights.Add(Numbers.ToNumber(digits, 0, digits.Length - i));                    
                }

                if (lefts.IsSubsetOf(primes) && 
                    rights.IsSubsetOf(primes))
                {
                    truncatablePrimes.Add(prime);
                }

                if (truncatablePrimes.Count == Max) break;
            }

            //Console.WriteLine($"Truncatable primes:");

            foreach (var truncatablePrime in truncatablePrimes)
            {
                //Console.WriteLine($"{truncatablePrime}");
            }

            Console.WriteLine($"Sum of eleven truncs: {truncatablePrimes.Sum()}");
        }
    }
}
