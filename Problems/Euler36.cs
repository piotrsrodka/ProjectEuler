using Common;
using System.Diagnostics;

namespace Euler
{
    public class Euler36
    {
        public static void Start()
        {
            long sum = 0;

            for (int i = 1; i < 1000000; i++)
            {
                var base2 = Convert.ToString(i, 2);
                var digits = i.ToString();

                if (base2 == base2.Reverse() && digits == digits.Reverse())
                {
                    sum += i;
                }
            }

            Trace.WriteLine($"Sum of all palindromic under one million: {sum}");
        }
    }
}
