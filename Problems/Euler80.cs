using System.Numerics;

namespace Euler
{
    internal class Euler80 : IEulerProblem
    {
        public void Start()
        {
            int digits = 2;
            int SumOfSums = 0;

            for (BigInteger i = 2; i <= 99; i++)
            {
                BigInteger number = BigInteger.Pow(10, 101 * digits);
                number = i * number;
                BigInteger sqrt = Sqrt(i, number);
                int sum = SumOfDigits(sqrt.ToString());
                SumOfSums += sum;
                // Console.WriteLine($"Input = {i}, Sqrt = {sqrt}, sum = {sum}");
            }

            Console.WriteLine($"Answer is {SumOfSums} (40886)");
        }

        int SumOfDigits(string number102)
        {
            if (number102.Length < 2) return 0;

            string number100 = number102.Substring(0, 100);
            char[] array = number100.ToCharArray();
            int sum = 0;

            foreach (char c in array)
            {
                sum += c - '0';
            }

            return sum;
        }

        BigInteger Sqrt(BigInteger a, BigInteger number)
        {
            if (a == 0) return 0;
            if (a == 1) return 1;
            if (a == 4 || a == 9 || a == 16 || a == 25 || a == 36 || a == 49 || a == 64 || a == 81) return 0;

            BigInteger x1 = number / 10; // first guess
            BigInteger x2 = 0;
            BigInteger div = 0;

            int i = 0;
            int max = 1000; // iterations

            while (i < max)
            {
                div = number / x1;
                x2 = (x1 + div) / 2;   // Newton method for square root

                if (BigInteger.Abs(x2 - x1) == 0)
                {
                    // Console.WriteLine($"Precise, i = {i}");
                    break;
                }

                x1 = x2;

                i++;
            }

            if (i == max) Console.WriteLine("Not Precise!");

            return x2;
        }
    }
}
