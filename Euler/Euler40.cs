using System;
using System.Text;

namespace Euler
{
    public class Euler40
    {
        public static void Start()
        {
            var builder = new StringBuilder();
            int i = 1;

            while (builder.Length < 1000000)
            {
                builder.Append(i.ToString());
                i++;
            }

            string fraction = builder.ToString();
            int result = 1;

            for (int j = 1; j <= 1000000; j*=10)
            {
                result *= Convert.ToInt32(fraction.Substring(j - 1, 1));
            }

            Console.WriteLine($"Result = {result}");
        }
    }
}
