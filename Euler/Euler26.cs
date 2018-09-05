using System;
using System.Numerics;

namespace Euler
{
    class Euler26 : IEulerProblem
    {
        public void Start()
        {
            const int decimalPlaces = 4000;
            int[] fractionArray = new int[decimalPlaces];
            int maxCycle = 0;
            var bigInt = SetMax(decimalPlaces);

            for (BigInteger denominator = 1; denominator < 1000; denominator+=2)
            {
                var fraction = bigInt / denominator;
                
                for (int i = 1; i <= decimalPlaces; i++)
                {
                    fraction = fraction / 10;
                    var digit = fraction % 10;                    
                    fractionArray[decimalPlaces - i] = (int)digit;
                }

                int cycle = 0;
                int shift1 = 0;
                int shift2 = 0;

                for (int shift = 1; shift <= decimalPlaces / 2 && cycle == 0; shift++)
                {
                    bool zeroFlag = true;

                    for (int i = 0; i + shift < decimalPlaces; i++)
                    {
                        var difference = fractionArray[i] - fractionArray[i + shift];

                        if (difference != 0)
                        {
                            zeroFlag = false;
                            break;
                        }
                    }

                    if (zeroFlag == true)
                    {
                        if (shift1 == 0)
                        {
                            shift1 = shift;
                        }
                        else
                        {
                            if (shift2 == 0)
                            {
                                shift2 = shift;
                                cycle = shift2 - shift1;
                                break;
                            }
                        }
                    }
                }

                if (cycle > maxCycle)
                {
                    maxCycle = cycle;
                    Console.WriteLine("{0:0000} - cycle: {1}", denominator, maxCycle);
                }
            }

            Console.ReadKey();
        }
        
        private static BigInteger SetMax(int power)
        {
            BigInteger max = 10;

            for (int i = 0; i < power; i++)
            {
                max = max * 10;
            }

            Console.WriteLine("Decimal points {0}", power);
            return max;
        }
    }
}
