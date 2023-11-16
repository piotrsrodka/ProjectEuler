namespace Euler
{
    public class Euler52 : IEulerProblem
    {
        public void Start()
        {
            for (int i = 100; i < int.MaxValue; i++)
            {
                var digits = ToDigitSet(i);

                if (!IsSameDigits(digits, 2 * i)) { continue; }
                if (!IsSameDigits(digits, 3 * i)) { continue; }
                if (!IsSameDigits(digits, 4 * i)) { continue; }
                if (!IsSameDigits(digits, 5 * i)) { continue; }
                if (!IsSameDigits(digits, 6 * i)) { continue; }

                Console.WriteLine($"This is it! {i}, {2 * i}, {3 * i}, {4 * i}, {5 * i}, {6 * i}");
                break;
            }
        }

        private bool IsSameDigits(HashSet<int> digits, int number)
        {
            return digits.SetEquals(ToDigitSet(number));
        }

        private HashSet<int> ToDigitSet(int number)
        {
            var digits = new HashSet<int>();

            while (number > 0)
            {
                digits.Add(number % 10);
                number /= 10;
            }

            return digits;
        }
    }
}
