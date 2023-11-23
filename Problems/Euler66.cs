using System.Numerics;

namespace Euler
{
    internal class Euler66 : IEulerProblem
    {
        public void Start()
        {
            Console.WriteLine($"Sqrt{4} = {Sqrt(4,2)}");
            Console.WriteLine($"Sqrt{2500} = {Sqrt(2500, 2500/2)}");
            Console.WriteLine($"Sqrt{16} = {Sqrt(16,8)}");
            Console.WriteLine($"Sqrt{49} = {Sqrt(49,25)}");
            Console.WriteLine($"Sqrt{8} = {Sqrt(8,2)}");
            Console.WriteLine($"Sqrt{1000000} = {Sqrt(1000000, 1000000/2)}");

            BigInteger MaxX = 0;
            BigInteger maxD = 0;

            for (BigInteger D = 2; D <= 100; D++)
            {
                bool isDPerfect = IsBigIntegerPerfectSquare(D).Item1;
                if (isDPerfect) continue; // ommit square D

                Console.WriteLine($"D: {D}");
                BigInteger a = D;
                BigInteger b = D;

                while (true)
                {
                    BigInteger smaller = a / D;

                    BigInteger expression = (a + 2) * smaller;

                    Tuple<bool, BigInteger> tuple = IsBigIntegerPerfectSquare(expression);

                    if (tuple.Item1)
                    {
                        BigInteger y = tuple.Item2;
                        
                        if (a + 1 > MaxX) 
                        { 
                            MaxX = a + 1;
                            maxD = D;
                            bool isIt = true; // CheckDiophantes(MaxX, y, D);
                            
                            if (!isIt) Console.WriteLine($"Check failed., for D = {D}");
                            else Console.WriteLine($"Found x = {a + 1}, for D = {D}, y = {y}");
                        }   
                        
                        break;
                    }

                    smaller = b / D;
                    expression = (b - 2) * smaller;

                    tuple = IsBigIntegerPerfectSquare(expression);

                    if (tuple.Item1)
                    {
                        BigInteger y = tuple.Item2;
                         
                        if (b - 1 > MaxX) { 
                            MaxX = b - 1; 
                            maxD = D;
                            bool isIt = true; // CheckDiophantes(MaxX, y, D);
                            
                            if (!isIt) Console.WriteLine($"Check failed., for D = {D}");
                            else Console.WriteLine($"Found x = {b - 1}, for D = {D}, y = {y}");
                        }

                        break;
                    }

                    a += D;
                    b += D;
                }
            }

            Console.WriteLine($"Max X is {MaxX}, for D = { maxD }");
        }

        private bool CheckDiophantes(long x, long y, long D)
        {
            double diff = x * x - y * y * D;
            bool isIt = (int) diff == 1;
            return isIt;
        }

        private double CheckY(long D, long x)
        {
            long inside = (x - 1) * (x + 1) / D;
            if (inside == 0) Console.WriteLine($"Y is zero! for D = { D }");
            return Math.Sqrt(inside);
        }

        BigInteger Sqrt(BigInteger N, BigInteger guess)
        {
            if (N == 0) return 0;
            if (N == 1) return 1;
            // if (N < long.MaxValue) return (BigInteger) Math.Sqrt((long)N);

            BigInteger nextGuess;
            int i = 0;

            while(true)
            {
                nextGuess = (guess + N / guess) / 2;
                if (guess  == nextGuess) 
                    break;
                if (i > 100)
                    break;
                guess = nextGuess;
                i++;
            }

            return nextGuess;
        }

        Tuple<bool, BigInteger> IsBigIntegerPerfectSquare(BigInteger originalNumber)
        {
            BigInteger root = Sqrt(originalNumber, originalNumber / 2);
            bool result = root * root == originalNumber;
            return new Tuple<bool, BigInteger> (result, root);
        }

        BigInteger Abs(BigInteger N)
        {
            if (N >= 0) return N; 
            else return -N;
        }

        private bool IsPerfectSquare(long number)
        {
            double root = Math.Sqrt(number);
            return IsInteger(root);
        }

        private Tuple<bool, long> IsPerfectSquareSO(long input)
        {
            long closestRoot = (long)Math.Sqrt(input);
            bool isIt = input == closestRoot * closestRoot;
            return new Tuple<bool, long>(isIt, closestRoot);
        }

        private bool IsInteger(double d)
        {
            bool isInteger = (d - Math.Floor(d)) < double.Epsilon;
            return isInteger;
        }
    }
}
