using Common;

namespace Euler
{
    public class Euler32 : IEulerProblem
    {
        HashSet<int>? panDigits;

        public void Start()
        {
            panDigits = new HashSet<int>();

            for (int a = 1; a <= 9; a++)
            {
                InnerLoop(a, 9876);
            }

            for (int a = 12; a <= 98; a++)
            {
                InnerLoop(a, 987);
            }

            Console.WriteLine($"Sum of pandigits products: {panDigits.Sum()}");
        }

        private void InnerLoop(int a, int maxB)
        {
            for (int b = a + 1; b <= maxB; b++)
            {
                int c = a * b;

                if (c > 9876) break;

                var da = Numbers.ToDigits(a);
                var db = Numbers.ToDigits(b);
                var dc = Numbers.ToDigits(c);

                var digits = da.Concat(db).Concat(dc).ToArray();

                if (digits.Any(x => x == 0)) continue;

                var digitSet = new HashSet<int>(digits);

                if (digitSet.Count == 9)
                {
                    if (panDigits != null && panDigits.Add(c))
                    {
                        Console.WriteLine($"Found pandigit: {a} x {b} = {c}");
                    }
                }
            }
        }
    }
}
