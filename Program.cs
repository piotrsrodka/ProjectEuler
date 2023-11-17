namespace Euler
{

    public class Progam
    {
        private static bool debug = false;

        public static void Main()
        {
            int numberOfRuns = 10;

            /* Choose your problem ;P 
             * Descritpion is available at:
             * https://projecteuler.net/problem=<problemNumber>
             * or
             * https://projecteuler.net/archives
             */
            int problemNumber = 58;

            string eulerProblemName = "Euler.Euler" + problemNumber;
            var eulerType = Type.GetType(eulerProblemName);

            if (eulerType == null)
            {
                throw new Exception($"Euler problem {problemNumber} not found");
            }

            IEulerProblem? problem = Activator.CreateInstance(type: eulerType) as IEulerProblem;

            Console.WriteLine($"\n\nEuler Project problem number {problemNumber}\n");

            var watch = System.Diagnostics.Stopwatch.StartNew();

            if (debug) Console.SetOut(TextWriter.Null);
            
            for (int i = 0; i < numberOfRuns; i++)
            {
                problem?.Start();
            }
          
            if (debug)
            {
                var standardOutput = new StreamWriter(Console.OpenStandardOutput());
                standardOutput.AutoFlush = true;
                Console.SetOut(standardOutput);
            }
            watch.Stop();

            Console.WriteLine();
            Console.WriteLine("Time: {0} ms ({1} runs average)\n\n",
                watch.ElapsedMilliseconds / numberOfRuns, numberOfRuns);
        }
    }
}