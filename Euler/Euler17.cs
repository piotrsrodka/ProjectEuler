using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    public class Euler17
    {
        public static void Start()
        {
            int letters = 0;

            int and = 3;

            int one = 3;
            int two = 3;
            int three = 5;
            int four = 4;
            int five = 4;
            int six = 3;
            int seven = 5;
            int eight = 5;
            int nine = 4;
            int ten = 3;

            int eleven = 6;
            int twelve = 6;
            int thirteen = 8;
            int fourteen = 8;
            int fifteen = 7;
            int sixteen = 7;
            int seventeen = 9;
            int eighteen = 8;
            int nineteen = 8;
            int twenty = 6;

            int thirty = 6;
            int forty = 5;
            int fifty = 5;
            int sixty = 5;
            int seventy = 7;
            int eighty = 6;
            int ninety = 6;
            int hundred = 7;

            int thousand = 8;

            List<int> Numbers = new List<int>
            {
                one, two, three, four, five, six, seven, eight, nine, ten,
                eleven, twelve, thirteen, fourteen, fifteen, sixteen, seventeen, eighteen, nineteen, twenty,
                thirty, forty, fifty, sixty, seventy, eighty, ninety, one + hundred
            };

            int units = Numbers.GetRange(0, 9).Sum();
            int teens = Numbers.GetRange(10, 9).Sum();

            int tens = Numbers.GetRange(19, 8).Sum();

            letters += units + ten;
            letters += teens;
            letters += 10 * twenty + units;    // up to 29
            letters += 10 * thirty + units;
            letters += 10 * forty + units;
            letters += 10 * fifty + units;
            letters += 10 * sixty + units;
            letters += 10 * seventy + units;
            letters += 10 * eighty + units;
            letters += 10 * ninety + units;    // up to 99

            int FirstHundred = letters;

            int FirstHundred2 = units + ten + teens + 10 * tens + 8 * units;

            letters += one + hundred;

            letters += FirstHundred + 99 * (one + hundred + and); // up to 199

            letters += two + hundred;

            letters += FirstHundred + 99 * (two + hundred + and); // up to 299

            letters += three + hundred;

            letters += FirstHundred + 99 * (three + hundred + and); // up to 399

            letters += four + hundred;

            letters += FirstHundred + 99 * (four + hundred + and); // up to 499

            letters += five + hundred;

            letters += FirstHundred + 99 * (five + hundred + and); // up to 599

            letters += six + hundred;

            letters += FirstHundred + 99 * (six + hundred + and); // up to 699

            letters += seven + hundred;

            letters += FirstHundred + 99 * (seven + hundred + and); // up to 799

            letters += eight + hundred;

            letters += FirstHundred + 99 * (eight + hundred + and); // up to 899

            letters += nine + hundred;

            letters += FirstHundred + 99 * (nine + hundred + and); // up to 999

            letters += one + thousand;

            Console.WriteLine("{0}", int.MaxValue);

            Console.WriteLine("{0}", units);

            Console.WriteLine("Letters Total: {0}", letters);
            Console.ReadKey();
        }
    }
}
