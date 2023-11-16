using Common;

namespace Euler
{
    public class Euler43 : IEulerProblem
    {
        public void Start()
        {
            List<string> list = new List<string>();
            long sum = 0;

            foreach (var number in Functions.Permute("1234567890"))
            {
                if (number[0] != '0')
                {
                    if (long.Parse(number.Substring(1, 3)) % 2 != 0) { continue; }
                    if (long.Parse(number.Substring(2, 3)) % 3 != 0) { continue; }
                    if (long.Parse(number.Substring(3, 3)) % 5 != 0) { continue; }
                    if (long.Parse(number.Substring(4, 3)) % 7 != 0) { continue; }
                    if (long.Parse(number.Substring(5, 3)) % 11 != 0) { continue; }
                    if (long.Parse(number.Substring(6, 3)) % 13 != 0) { continue; }
                    if (long.Parse(number.Substring(7, 3)) % 17 != 0) { continue; }

                    sum += long.Parse(number);
                }
            }

            Console.WriteLine($"Sum of pandigits having strange property: {sum}");
        }


    }
}
