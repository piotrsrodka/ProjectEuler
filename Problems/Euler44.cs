using Common;

namespace Euler
{
    public class Euler44 : IEulerProblem
    {
        public void Start()
        {
            var pentagons = new HashSet<long>();

            for (int i = 1; i < 10000; i++)
            {
                pentagons.Add(Functions.Pentagon(i));
            }

            long minD = long.MaxValue;

            for (int i = 1; i < 10000; i++)
            {
                for (int j = i + 1; j < 10000; j++)
                {
                    long pi = Functions.Pentagon(i);
                    long pj = Functions.Pentagon(j);
                    long D = pj - pi;

                    if (pentagons.Contains(D) && pentagons.Contains(pi + pj))
                    {
                        if (D < minD)
                        {
                            minD = D;
                            Console.WriteLine($"Small step D: {D}. P({j}) and P({i})");
                        }
                    }
                }
            }

            Console.WriteLine($"Min D = {minD}");
        }
    }
}
