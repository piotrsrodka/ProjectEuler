using Common;

namespace Euler
{
    public class Euler33 : IEulerProblem
    {
        public void Start()
        {
            int numerator = 1;
            int denominator = 1;

            for (int a = 11; a < 100; a++)
            {
                if (a % 10 == 0) continue;

                for (int b = a + 1; b < 100 ; b++)
                {
                    var aa = Numbers.ToDigits(a);
                    var bb = Numbers.ToDigits(b);

                    if (b % 10 == 0) continue;

                    if (((double)a / b == (double)aa[1] / bb[0] && aa[0] == bb[1]) ||
                        ((double)a / b == (double)aa[0] / bb[1] && aa[1] == bb[0]))
                    {
                        Console.WriteLine($"Found curious: {a}/{b}!");
                        numerator *= a;
                        denominator *= b;
                    }
                }
            }

            Console.WriteLine($"Denominator of the product: {numerator}/{denominator}");
        }
    }
}
