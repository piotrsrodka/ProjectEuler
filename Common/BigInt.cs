using System;
using System.Text;

namespace Common
{
    public class BigInt
    {
        public int Digits { get; set; }
        public byte[] a { get; set; }

        public BigInt(int digits)
        {
            Digits = digits;
            a = new byte[Digits];
        }

        public BigInt(long number)
        {
            Digits = 1;
            long copy = number;
            while ((copy /= 10) > 0) Digits++;
            a = new byte[Digits];

            for (int i = 0; i < Digits; i++)
            {
                a[i] = (byte)(number % 10);
                number /= 10;
            }
        }

        public static BigInt operator *(BigInt @this, BigInt that)
        {
            BigInt result = new BigInt(@this.Digits + that.Digits);
            BigInt[] subProduct = new BigInt[@this.Digits];

            for (int i = 0; i < @this.Digits; i++)
            {
                int remainder = 0;
                subProduct[i] = new BigInt(@this.Digits + that.Digits);

                for (int j = 0; j < that.Digits; j++)
                {
                    int product = @this.a[i] * that.a[j] + remainder;

                    if ((product / 10) > 0)
                    {
                        remainder = product / 10;
                    }
                    else
                    {
                        remainder = 0;
                    }

                    subProduct[i].a[j] = (byte)(product % 10);
                }

                subProduct[i].a[that.Digits] += (byte)remainder;
                subProduct[i].Exp(i);
            }

            /* time to add subproducts together */
            int rem = 0;

            for (int j = 0; j < @this.Digits + that.Digits; j++)
            {
                int subSum = rem;

                for (int i = 0; i < @this.Digits && i <= j + 1; i++)
                {
                    subSum += subProduct[i].a[j];
                }

                if (subSum > 9)
                {
                    rem = subSum / 10;
                    subSum = subSum % 10;
                }
                else
                {
                    rem = 0;
                }

                result.a[j] = (byte)subSum;
            }

            int checkSum = 0;

            foreach (byte a in result.a) checkSum += a;

            if (checkSum > 0)
            {
                int digit = result.Digits - 1;

                while (result.a[digit] == 0)
                {
                    digit--;
                }

                BigInt newResult = new BigInt(digit + 1);

                for (int i = 0; i < newResult.Digits; i++)
                {
                    newResult.a[i] = result.a[i];
                }

                result = newResult;
            }

            return result;
        }
        /*        
         *      1024    j   that
         *        13    i   this
         *      ----
         *     03072
         *     10240    
         *      
         */

        private void Exp(int exp)
        {
            for (int i = 0; i < exp; i++)
            {
                this.TenTimes();
            }
        }

        private void TenTimes()
        {
            int RealDigits = Digits - 1;
            while (this.a[RealDigits] == 0)
            {
                --RealDigits;
                if (RealDigits < 0) return;
            }
            RealDigits++;

            for (int i = RealDigits; i > 0; --i)
            {
                a[i] = a[i - 1];
            }
            a[0] = 0;
        }

        public static BigInt operator +(BigInt thisa, BigInt that)
        {
            BigInt bigger = thisa.Digits > that.Digits ? thisa : that;
            int digits = Math.Max(thisa.Digits, that.Digits);
            int minDigits = Math.Min(thisa.Digits, that.Digits);
            digits++;
            BigInt result = new BigInt(digits);
            /*      11
             *      999
             *   +   99
             *   ------
             *      1098 
             */
            int remainder = 0;
            int sum;

            for (int i = 0; i < minDigits; i++)
            {
                sum = thisa.a[i] + that.a[i] + remainder;

                if (sum > 10)
                {
                    remainder = 1;
                    sum %= 10;
                }
                else
                {
                    remainder = 0;
                }

                result.a[i] = (byte)sum;
            }

            sum = 0;

            while (remainder > 0 && minDigits < bigger.Digits)
            {
                sum = bigger.a[minDigits] + (byte)remainder;

                if (sum > 9)
                {
                    remainder = 1;
                    sum %= 10;
                }
                else
                {
                    remainder = 0;
                }

                result.a[minDigits] = (byte)sum;
                minDigits++;
            }

            result.a[minDigits] = (byte)remainder;

            for (int i = minDigits + 1; i < bigger.Digits; i++)
            {
                result.a[i] = bigger.a[i];
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = Digits - 1; i >= 0; i--)
            {
                sb.Append(a[i]);
            }

            return sb.ToString();
        }
    }
}
