using System.Numerics;

namespace Euler
{
    class Euler25 : IEulerProblem
    {
        public void Start()
        {            
            BigInteger F1 = new BigInteger(1L);
            BigInteger F2 = new BigInteger(1L);
            BigInteger Fn = F1 + F2;
            int n = 2;
            int digits = (int)Math.Floor(BigInteger.Log10(Fn) + 1);

            while (digits < 1000)
            {
                Fn = F1 + F2;
                F1 = F2;
                F2 = Fn;
                n++;
            }

            digits = (int)Math.Floor(BigInteger.Log10(Fn) + 1);
            Console.WriteLine("F{0} has {1} digits", n, digits);       
        }
    }
}
