namespace Euler
{
    public static class Fractions
    {
        public static double  InfiniteCycleFraction(int enumerations, double[] cyclic)
        {
            if (enumerations == 0)
            {
                return 1.0 / cyclic[0];
            }

            int element = enumerations % cyclic.Length;

            return 1.0 / (cyclic[element] + InfiniteCycleFraction(enumerations - 1, cyclic));
        }

        public static double InfiniteFraction(int enumerations, double number)
        {
            if (enumerations == 0)
            {
                return 1.0 / number;
            }

            return 1.0 / (number + InfiniteFraction(enumerations - 1));
        }

        public static double InfiniteFraction(int enumerations)
        {
            if (enumerations == 0)
            {
                return 0.5;
            }

            return 1 / (2 + InfiniteFraction(enumerations - 1));
        }
    }
}
