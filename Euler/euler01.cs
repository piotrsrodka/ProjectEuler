using System;

namespace Euler {

	public class Euler1 : IEulerProblem
	{
		public void Start() 
		{
			int[] n = new int[40];
			int sum = 2;
			int i = 2;

            n[0] = 1;
            n[1] = 2;

			Console.WriteLine("{0}, {1}", 1, n[0]);
			Console.WriteLine("{0}, {1}", 2, n[1]);
			
			do {
				n[i] = n[i - 1] + n[i - 2];
				if (n[i] > 4000000) break;
				if (n[i] % 2 == 0) sum += n[i];
				Console.WriteLine("{0}, {1}, {2}", i + 1, n[i], sum);
				i++;
			} while (true);
			
			Console.WriteLine("{0}", sum);
		}
	}
}