using System.Diagnostics;

namespace Euler
{
    public class Euler07 : IEulerProblem
    {
        public void Start()
        {
            const int MaxNumber = 500000; //I shoot the number
            short[] MarkArray = new short[MaxNumber + 1];
            int primeOrder = 0;
            const short NotPrime = 1;
            const short Prime = 0;

            for (int i = 2; i < MaxNumber; i++)
            {
                MarkArray[i] = Prime;
            }

            for (int i = 2; i < MaxNumber; i++)
            {
                if (MarkArray[i] == NotPrime) continue;

                primeOrder++;

                for (int j = 2 * i; j < MaxNumber; j += i)
                {
                    MarkArray[j] = NotPrime;

                    //if (primeOrder == 10001)
                    //{
                    //    Trace.WriteLine("{0}", i.ToString());
                    //    break;
                    //}
                }
            }

            for (int i = 0; i < MaxNumber; i++)
            {
                if (MarkArray[i] == Prime)
                {
                    Trace.WriteLine("{0}", i.ToString());
                }
            }
        }
    }
}
