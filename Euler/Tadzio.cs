using System;
using System.Numerics;
using System.Threading;

namespace Euler
{
    /* My 5 y.o. son's class to play with */
    public class Tadzio
    {
        public static void Start()
        {
            for (BigInteger i = 1; true; i*=13)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{i}");
                Thread.Sleep(500);
            }
        }
    }
}
