using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    public class Euler42
    {
        private readonly Dictionary<char, int> _alphabetValues = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            .ToDictionary(l => l, l => l - 'A' + 1);

        public void Start()
        {
            var triangles = GenerateTriangleNumbers();
            int count = 0;

            foreach (var word in Words42.words)
            {
                int value = EvaluateWord(word);
                if (triangles.Contains(value)) count++;
            }

            Console.WriteLine($"Number of triangles in dictionary: {count}");
        }

        private HashSet<int> GenerateTriangleNumbers()
        {
            var triangles = new HashSet<int>();

            for (int n = 1; n < 27; n++)
            {
                triangles.Add((n * (n + 1)) / 2);
            }

            return triangles;
        }

        private int EvaluateWord(string word)
        {
            int wordValue = 0;

            foreach (var character in word)
            {
                wordValue += _alphabetValues[character];
            }

            return wordValue;
        }
    }
}
