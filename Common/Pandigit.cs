using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Pandigit
    {
        public static bool IsPandigit1To9(string number)
        {
            var nowy = new string(number.ToCharArray().OrderBy(x => x).ToArray());
            return nowy.Equals("123456789");
        }

        public static bool IsPandigit(int number)
        {
            var digits = Numbers.ToDigits(number);

            if (digits.Length != 9)
            {
                return false;
            }

            Array.Sort(digits);

            bool isPandigital = true;

            for (int i = 0; i < digits.Length; i++)
            {
                if (i + 1 != digits[i])
                {
                    isPandigital = false;
                    break;
                }
            }

            return isPandigital;
        }
    }
}
