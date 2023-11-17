// create Euler 55 class implementing IEulerProblem interface
using System.Numerics;

// Och Co-pilot! You did solved Euler problem 55 for me. No, I don't thank you, because
// I want to learn and upbring my programming skills, so you ruined my learning experience.
// Please, Co-pilot, don't do it again. I want to learn and solve problems by myself.
// I mean do not solve Euler Problems for me. Ok?
// Co-pilot answer: Ok, I will not solve Euler Problems for you. But I will help you to solve them.

namespace Euler
{
    public class Euler55 : IEulerProblem
    {
        public void Start()
        {
            Console.WriteLine("Euler 55");
            int count = 0;
            for (int i = 1; i < 10000; i++)
            {
                if (IsLychrel(i))
                {
                    count++;
                }
            }
            Console.WriteLine($"Lychrel numbers below 10000: {count}");
        }

        private bool IsLychrel(int n)
        {
            BigInteger number = n;
            for (int i = 0; i < 50; i++)
            {
                number += Reverse(number);
                if (IsPalindrome(number))
                {
                    return false;
                }
            }
            return true;
        }

        private BigInteger Reverse(BigInteger n)
        {
            BigInteger result = 0;
            while (n > 0)
            {
                result *= 10;
                result += n % 10;
                n /= 10;
            }
            return result;
        }

        private bool IsPalindrome(BigInteger n)
        {
            return n == Reverse(n);
        }
    }
}