using Common;

namespace Euler
{
    internal class Euler58 : IEulerProblem
    {
        public void Start()
        {
            int allDiagonals = 1;
            int allNumberOfPrimes = 0;
            float ratio = 1;
            int actualSide = 0;
            var diagonals = new int[4];

            for (int side = 1; side <= 35000; side = side + 2)
            {
                int startingNumber = side * side + 1;
                actualSide = side + 2;
                
                diagonals[0] = startingNumber + actualSide - 2;
                diagonals[1] = diagonals[0] + actualSide - 1;
                diagonals[2] = diagonals[1] + actualSide - 1;
                diagonals[3] = diagonals[2] + actualSide - 1;

                int thisSpiralNumberOfPrimes = 0;

                for (int i = 0; i < 3; i++) // don't check right bottom diagonal
                {
                    if (PrimeNumbers.IsPrime(diagonals[i])) { thisSpiralNumberOfPrimes++; }
                }

                allNumberOfPrimes += thisSpiralNumberOfPrimes;
                allDiagonals +=4;
                ratio = (float) allNumberOfPrimes / allDiagonals;

                if (side < 10) Console.WriteLine($"Side: {actualSide} - Ratio: {ratio}");

                if (ratio < 0.1)
                {
                    Console.WriteLine($"BUM! Side: {actualSide} - Ratio: {ratio}"); 
                    break;
                }
            }

            Console.WriteLine($"Side: {actualSide} - Ratio: {ratio}");
        }
    }
}
