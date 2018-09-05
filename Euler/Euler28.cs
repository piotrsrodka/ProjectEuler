using System.Diagnostics;

namespace Euler
{
    public class Euler28
    {
        public static void Start()
        {
            int sum = 1;
            int n = 1;
            int size = 0;

            while (size < 1001)
            {
                size = 2 * n + 1;
                int TopRight = size * size;
                int BottomLeft = (size - 1) * (size - 1) + 1;
                int TopLeft = (TopRight + BottomLeft) / 2;
                int BottomRight = BottomLeft - size + 1;
                sum += TopRight + BottomLeft + TopLeft + BottomRight;
                n++;
            }

            Trace.WriteLine($"Sum of diagonals: {sum}");
        }
    }
}
