using System.Numerics;
using static Common.Functions;

namespace Common
{
    public static class Combinatorics
    {
        public static BigInteger Combination(long n, long k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }
    }
}
