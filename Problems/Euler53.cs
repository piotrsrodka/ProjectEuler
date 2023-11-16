using Common;

namespace Euler
{
    public class Euler53 : IEulerProblem
    {
        public void Start()
        {
            int result = 0;

            for (int n = 1; n <= 100; n++)
            {
                for (int k = 1; k <= n; k++)
                {
                    if (Combinatorics.Combination(n, k) > 1000000)
                    {
                        result++;
                    }
                }
            }

            Console.WriteLine($"We got {result} combinations higher than 1000000");
        }
    }
}
