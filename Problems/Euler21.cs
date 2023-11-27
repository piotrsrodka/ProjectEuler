/*
Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide 
evenly into n).
If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and 
each of a and b are called amicable numbers.

For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; 
therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

Evaluate the sum of all the amicable numbers under 10000.
*/

namespace Euler
{
    public class Euler21 : IEulerProblem
    {
        public void Start()
        {
            int limit = 10000;
            List<int> Amicables = new List<int>();
            int b;

            for (int a = 4; a < limit; a++)
            {
                b = Divisors(a);

                if (b != a && Divisors(b) == a)
                {
                    Amicables.Add(a);                    
                }
            }

            foreach (var item in Amicables)
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine("\nSum of Amicables: {0}", Amicables.Sum());
            Console.ReadKey();
        }

        private static int Divisors(int a)
        {
            List<int> properDivisors = new List<int>();
            int up = a / 2;
            for (int i = 1; i <= up; i++)
            {
                if (a % i == 0)
                {
                    properDivisors.Add(i);                    
                }
            }

            return properDivisors.Sum();
        }
    }
}
