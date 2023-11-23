namespace Euler
{
    internal class Euler65 : IEulerProblem
    {
        public void Start()
        {
            double square2 = Math.Sqrt(2);
            double square2numeric = 1 + Fractions.InfiniteFraction(10);
            double square2numeric2 = 1 + Fractions.InfiniteFraction(10, 2);
            Console.WriteLine($"{square2}");
            Console.WriteLine($"{square2numeric}");
            Console.WriteLine($"{square2numeric2}");

            Console.WriteLine($"V10 = {Math.Sqrt(10)}");
            Console.WriteLine($"V10 = {3 + Fractions.InfiniteCycleFraction(10, new double[] { 6 })}");

            Console.WriteLine($"V11 = {Math.Sqrt(11)}");
            Console.WriteLine($"V11 = {3 + Fractions.InfiniteCycleFraction(10, new double[] { 3, 6 })}");

            double square23 = Math.Sqrt(23);
            double[] cycle23 = new double[4] { 1, 3, 1, 8 };
            double square23numeric = 4+ Fractions.InfiniteCycleFraction(10, cycle23);
            Console.WriteLine($"{square23}");
            Console.WriteLine($"{square23numeric}");

        }

    }
}
