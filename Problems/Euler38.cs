using Common;
using System.Text;

namespace Euler
{
    class Euler38 : IEulerProblem
    {
        public void Start()
        {
            var list = new List<string>();

            for (int s = 2; s < 6; s++)
            {
                for (int i = 2; i < 10000; i++)
                {
                    string number = GetNUmber(s, i);

                    if (Pandigit.IsPandigit1To9(number))
                    {
                        Console.WriteLine($"Got it! {number}, set {s}, number {i}");
                        list.Add(number);
                    }
                }
            }

            list.Sort();
            Console.WriteLine($"Answer: {list[list.Count-1]}");
        }

        private static string GetNUmber(int s, int i)
        {
            var numberBuilder = new StringBuilder();

            for (int k = 1; k <= s; k++)
            {
                numberBuilder.Append(i * k);
            }

            return numberBuilder.ToString();
        }
    }
}
