using System.Diagnostics;

namespace Euler
{
    class Euler23 : IEulerProblem
    {
        public void Start()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Number {0} is abundant? {1}", 12, IsAbundant(12));
            List<int> AbundantList = new List<int>();
            int Max = 28123;
            for (int i = 12; i <= Max; i++)
            {
                if (IsAbundant(i)) AbundantList.Add(i);
            }
            HashSet<int> Sums = new HashSet<int>();
            int sum;            
            for (int i = 0; i < AbundantList.Count; i++)
            {
                for (int j = i; j < AbundantList.Count; j++)
                {
                    sum = AbundantList[i] + AbundantList[j];
                    if (sum <= Max) Sums.Add(sum);
                    else break;
                }
            }            
            sum = 0;
            for (int i = 1; i <= Max; i++)
            {
                if (!Sums.Contains(i)) sum += i;
            }
            sw.Stop();
            Console.WriteLine("Done. {0}", sum);
            Console.WriteLine("Elapsed time: {0} ms", sw.ElapsedMilliseconds);
            Console.ReadKey();
        }

        private static bool IsAbundant(int a)
        {
            int up = a / 2;
            int sum = 1;
            for (int i = 2; i <= up; i++)
            {
                if (a % i == 0)
                {
                    sum += i;                    
                    if (sum > a) return true;
                }
            }
            return false;
        }
    }
}
