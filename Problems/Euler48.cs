using System.Diagnostics;
using System.Numerics;

namespace Euler
{
    public class Euler48
    {
        public static void Start()
        {
            const long TenDigits = 10000000000;
            long sum = 0;            

            for (int i = 1; i <= 1000; i++)
            {
                sum += (long) BigInteger.ModPow(i, i, TenDigits);
            }

            Trace.WriteLine($"Last ten digits are: {sum % TenDigits}");
        }
    }
}
