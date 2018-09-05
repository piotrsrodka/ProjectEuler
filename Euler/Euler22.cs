using System;
using System.IO;

namespace Euler
{
    class Euler22 : IEulerProblem
    {
        public void Start()
        {
            using (StreamReader streamReader = new StreamReader(@"Data\\p022_names.txt"))
            {                
                string source = streamReader.ReadToEnd();
                source = source.Replace("\"", "");
                string[] Names = source.Split(',');
                Array.Sort(Names);
                int value = 0;

                for (int i = 0; i < Names.Length; i++)
                {
                    value += Value(Names[i]) * (i + 1);
                }

                Console.WriteLine("Total value = {0}", value);
                Console.ReadKey();
            }
        }

        static int Value(string name)
        {
            int value = 0;
            for (int i = 0; i < name.Length; i++)
            {
                value += name[i] - 'A' + 1;
            }
            return value;
        }
    }
}
