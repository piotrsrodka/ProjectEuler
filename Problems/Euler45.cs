namespace Euler
{
    public class Euler45
    {
        public void Start()
        {
            Console.WriteLine($"It can be verified that {T(285)} = {P(165)} = {H(143)}");

            long h = 143;

            while (true)
            {
                h++;
                var Hexa = H(h);

                var p = InverseP(Hexa);
                var floorP = (long)p;
                if (p > floorP) continue;
                var Penta = P(floorP);
                if (Hexa != Penta) continue;

                var t = InverseT(Hexa);
                var floorT = (long)(t);
                if (t > floorT) continue;
                var Tri = T(floorT);

                if (Hexa == Tri)
                {
                    Console.WriteLine($"Found it! T({t}) = P({p}) = H({h}) = {Hexa}");
                    break;
                }
            }
        }

        private long T(long n) { return (n * (n + 1)) / 2; }
        private long P(long n) { return (n * (3 * n - 1)) / 2; }
        private long H(long n) { return n * (2 * n - 1); }

        private double InverseT(long t) { return (Math.Sqrt(1 + 8 * t) - 1) / 2; }
        private double InverseP(long p) { return (1 + Math.Sqrt(1 + 24 * p)) / 6; }
    }
}
