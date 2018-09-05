using System.Collections.Generic;
using System.Numerics;

namespace Common
{
    public static class Functions
    {
        public static long Pentagon(long n)
        {
            return (n * (3 * n - 1)) / 2;
        }

        public static BigInteger Factorial(long n)
        {
            if (n == 1 || n == 0) return 1;
            return Factorial(n - 1) * n;
        }

        // Taken from https://en.wikipedia.org/wiki/Permutation#Software_implementations
        // Insert into all positions solution
        public static List<string> Permute(string input)
        {
            if (input.Length == 1)
            {
                return new List<string>() { input };
            }

            var permutations = new List<string>();
            var toInsert = input[0].ToString();

            foreach (var item in Permute(input.Substring(1)))
            {
                for (int i = 0; i <= item.Length; ++i)
                {
                    string newPermutation = item.Insert(i, toInsert);
                    permutations.Add(newPermutation);
                }
            }

            return permutations;
        }
    }
}
