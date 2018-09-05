using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Euler24 : IEulerProblem
    {
        static List<int> Digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public void Start()
        {
            Console.WriteLine("Factorial {0} = {1}", 5, Factorial(5));
            
            int sum = 0;
            int goal = 1000000;
            int positions = 9;
            int digit = 0;
            long answer = 0;
            while (sum != goal)
            {          
                if (sum + Factorial(positions) > goal)
                {                    
                    positions--;
                    Console.WriteLine(sum);
                    answer = answer * 10 + digit;
                    Digits.Remove(digit);
                    digit = -1;
                }
                else
                {
                    sum += Factorial(positions);
                    if (sum == goal)
                    {
                        answer = answer * 10 + digit;
                        Digits.Remove(digit);
                        Console.WriteLine("Sum = {0}", sum);
                        break;
                    }
                    
                }
                digit = NextDigit(digit);
                if (digit == -1) Console.WriteLine("ERRRORRR!!!");
            }
            
            List<int> sortedRemains = new List<int>();
            foreach (var item in Digits)
            {
                sortedRemains.Add(item);
            }
            sortedRemains.Sort();
            for (int i = 0; i < sortedRemains.Count; i++)
            {
                answer = answer * 10 + sortedRemains[i];
            }
            Console.WriteLine(answer);
            Console.ReadKey();
        }

        private static int NextDigit(int digit)
        {
            for (int i = digit + 1; i < 10; i++)
            {
                if (Digits.Contains(i)) return i;
            }
            return -1;
        }

        private static int Factorial(int a)
        {
            int result = 1;
            for (int i = 1; i <= a; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
