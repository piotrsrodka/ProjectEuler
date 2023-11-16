using Common;

namespace Euler
{
    class Euler20 : IEulerProblem
    {
        public void Start()
        {
            // n! means n × (n − 1) × ... × 3 × 2 × 1

            // For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
            // and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

            // Find the sum of the digits in the number 100!

            int N = 100;
            BigInt factorial = new BigInt(1L);

            for (int i = 2; i <= N; i++)
            {
                factorial = factorial * new BigInt((long)i);
                Console.WriteLine("{0}! = {1}", i, factorial);
            }

            int checkSum = 0;
            foreach (byte a in factorial.A) checkSum += a;
            Console.WriteLine("Sum of digits = {0}", checkSum);

            BigInt big1 = new BigInt(99L);
            Console.WriteLine(big1);

            BigInt big2 = new BigInt(99L);
            Console.WriteLine(big2);

            BigInt Sum = big2 + big1;
            Console.WriteLine("Result of {0} + {1} = {2}", big2, big1, Sum);

            BigInt Multiply = big2 * big1;
            Console.WriteLine("Result of {0} x {1} = {2}", big2, big1, Multiply);
        }
    }
}
