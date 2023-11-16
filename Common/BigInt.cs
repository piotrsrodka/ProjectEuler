using System.Text;

namespace Common
{
    public class BigInt
    {
        public int Digits { get; set; }
        public byte[] A { get; set; }

        public BigInt(int digits)
        {
            Digits = digits;
            A = new byte[Digits];
        }

        public BigInt(long number)
        {
            Digits = 1;
            long copy = number;
            while ((copy /= 10) > 0) Digits++;
            A = new byte[Digits];

            for (int i = 0; i < Digits; i++)
            {
                A[i] = (byte)(number % 10);
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
                    int product = @this.A[i] * that.A[j] + remainder;

                    if ((product / 10) > 0)
                    {
                        remainder = product / 10;
                    }
                    else
                    {
                        remainder = 0;
                    }

                    subProduct[i].A[j] = (byte)(product % 10);
                }

                subProduct[i].A[that.Digits] += (byte)remainder;
                subProduct[i].Exp(i);
            }

            /* time to add subproducts together */
            int rem = 0;

            for (int j = 0; j < @this.Digits + that.Digits; j++)
            {
                int subSum = rem;

                for (int i = 0; i < @this.Digits && i <= j + 1; i++)
                {
                    subSum += subProduct[i].A[j];
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

                result.A[j] = (byte)subSum;
            }

            int checkSum = 0;

            foreach (byte a in result.A) checkSum += a;

            if (checkSum > 0)
            {
                int digit = result.Digits - 1;

                while (result.A[digit] == 0)
                {
                    digit--;
                }

                BigInt newResult = new BigInt(digit + 1);

                for (int i = 0; i < newResult.Digits; i++)
                {
                    newResult.A[i] = result.A[i];
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
            while (this.A[RealDigits] == 0)
            {
                --RealDigits;
                if (RealDigits < 0) return;
            }
            RealDigits++;

            for (int i = RealDigits; i > 0; --i)
            {
                A[i] = A[i - 1];
            }
            A[0] = 0;
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
                sum = thisa.A[i] + that.A[i] + remainder;

                if (sum > 10)
                {
                    remainder = 1;
                    sum %= 10;
                }
                else
                {
                    remainder = 0;
                }

                result.A[i] = (byte)sum;
            }

            sum = 0;

            while (remainder > 0 && minDigits < bigger.Digits)
            {
                sum = bigger.A[minDigits] + (byte)remainder;

                if (sum > 9)
                {
                    remainder = 1;
                    sum %= 10;
                }
                else
                {
                    remainder = 0;
                }

                result.A[minDigits] = (byte)sum;
                minDigits++;
            }

            result.A[minDigits] = (byte)remainder;

            for (int i = minDigits + 1; i < bigger.Digits; i++)
            {
                result.A[i] = bigger.A[i];
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = Digits - 1; i >= 0; i--)
            {
                sb.Append(A[i]);
            }

            return sb.ToString();
        }
    }
}
