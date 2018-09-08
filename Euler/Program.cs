using System;

namespace Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRuns = 1;

            /* Choose your problem ;P 
             * Descritpion is available at:
             * https://projecteuler.net/problem=<problemNumber>
             * or
             * https://projecteuler.net/archives
             */
            int problemNumber = 17;
            
            string eulerProblemName = "Euler.Euler" + problemNumber;
            var eulerType = Type.GetType(eulerProblemName);
            
            IEulerProblem problem = (IEulerProblem)Activator.CreateInstance(eulerType);

            Console.WriteLine($"Euler Project problem number {problemNumber}");

            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < numberOfRuns; i++)
            {
                problem.Start();
            }
            
            watch.Stop();

            Console.WriteLine();
            Console.WriteLine("Elapsed time: {0} ms ({1} runs average)", 
                watch.ElapsedMilliseconds / numberOfRuns, numberOfRuns);
        }
    }
}
