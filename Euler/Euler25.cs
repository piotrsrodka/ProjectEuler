using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Diagnostics;
using System.Threading;
using System.Numerics;

namespace Euler
{
    class Euler25 : IEulerProblem
    {
        public void Start()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
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
                //Console.WriteLine("F{0} = {1}, Digits = {2}", ++n, Fn, Fn.Digits);
                //Console.WriteLine("F{0} has {1} digits", ++n, Fn.Digits);
            }
            digits = (int)Math.Floor(BigInteger.Log10(Fn) + 1);
            Console.WriteLine("F{0} has {1} digits", n, digits);
            //Console.WriteLine("F{0} = {1}", n, Fn);
            sw.Stop();            
            Console.WriteLine("Elapsed time: {0} ms", sw.ElapsedMilliseconds);

            //for (int i = 0; i <= 1000; i++)
            //{
            //    Thread.Sleep(10);
            //    Console.Write("{0}, ", i);
            //}

            Console.ReadKey();
        }
    }
}
