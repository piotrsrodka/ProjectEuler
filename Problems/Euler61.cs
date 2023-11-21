namespace Euler
{
    internal class Euler61 : IEulerProblem
    {
        List<string>[] PolyNumbers = new List<string>[6];

        public void Start()
        {
            int min = 1;
            int max = 1000;
            int[] mins = { min, min, min, min, min, min };
            int[] maxs = { max, max, max, max, max, max };

            // Prepare 4 digits sets of polygonal numbers
            for (int i = 0; i < 6; i++)
            {
                PolyNumbers[i] = new List<string>();
                bool minSet = false;

                for (int n = mins[i]; n <= maxs[i]; n++)
                {
                    int polyNumber = PolygonalNumber(i, n);

                    if (!minSet && polyNumber > 999)
                    {
                        mins[i] = n;
                        minSet = true;
                    }

                    if (polyNumber > 9999)
                    {
                        maxs[i] = n;
                        break;
                    }


                    if (minSet)
                    {
                        PolyNumbers[i].Add(polyNumber.ToString());
                    }
                }
            }

            int topLevelSet = 0;
            int[] remainingSets = { 1, 2, 3, 4, 5 };

            foreach (string number in PolyNumbers[topLevelSet])
            {
                string infoText = "(" + topLevelSet.ToString() + ")" + number;
                RecurentSearch(number, topLevelSet, remainingSets, topLevelSet, infoText, int.Parse(number));
            }
        }

        private void RecurentSearch(string number, int currentSet, int[] remainingSets, int topLevelSet, string infoText, int sum)
        {
            string substring = number.Substring(2, 2);

            foreach (int nextSet in remainingSets.Where(s => s != currentSet))
            {
                foreach (string? next in PolyNumbers[nextSet].Where(x => x.Substring(0, 2) == substring))
                {
                    string innerInfoText = infoText + " -> (" + nextSet.ToString() + ") " + next;
                    int innerSum = sum + int.Parse(next);

                    int[] innerRemainingSet = remainingSets.Where(s => s != nextSet).ToArray();

                    if (innerRemainingSet.Length > 0)
                    {
                        RecurentSearch(next, nextSet, innerRemainingSet, topLevelSet, innerInfoText, innerSum);
                    }
                    else
                    {
                        string nextSubstring = next.Substring(2, 2);
                        string firstNumberSubstring = infoText.Substring(3, 2);

                        if (firstNumberSubstring == nextSubstring)
                        {
                            string theLastNumber = PolyNumbers[topLevelSet].First(x => x.Substring(0, 2) == nextSubstring);
                            Console.WriteLine($"Found! {innerInfoText}, sum = {innerSum}");
                            infoText = "";
                        }

                        infoText = "";
                        return;
                    }
                }
            }

            infoText = "";
            return;
        }

        private int PolygonalNumber(int poly, int number)
        {
            switch (poly)
            {
                case 0: return Triangle(number);
                case 1: return Square(number);
                case 2: return Pentagonal(number);
                case 3: return Hexagonal(number);
                case 4: return Heptagonal(number);
                case 5: return Octagonal(number);
                default: throw new Exception("Error formula");
            }
        }

        private int Triangle(int n)
        {
            if (n == 1) return 1;

            return (n * n + n) / 2;
        }

        private int Square(int n)
        {
            if (n == 1) return 1;

            return n * n;
        }

        private int Pentagonal(int n)
        {
            if (n == 1) return 1;

            return (3 * n * n - n) / 2;
        }

        private int Hexagonal(int n)
        {
            if (n == 1) return 1;

            return (2 * n * n - n);
        }

        private int Heptagonal(int n)
        {
            if (n == 1) return 1;

            return (5 * n * n - 3 * n) / 2;
        }

        private int Octagonal(int n)
        {
            if (n == 1) return 1;

            return 3 * n * n - 2 * n;
        }
    }
}
