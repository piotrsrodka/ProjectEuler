using System.Numerics;

namespace Common
{
    public struct Rational
    {
        /*
         * 
         *   nominator
         *  -----------
         *  denominator
         * 
         */

        private readonly BigInteger _nominator;
        private readonly BigInteger _denominator;

        public BigInteger Nominator { get { return _nominator; } }
        public BigInteger Denominator { get { return _denominator; } }

        public Rational(BigInteger nominator)
        {
            _nominator = nominator;
            _denominator = 1;
        }

        public Rational(BigInteger nominator, BigInteger denominator)
        {
            if (denominator == 0) { throw new System.DivideByZeroException(); }

            // Simplify fraction when constructing Rational number
            var nominatorDivisors = Divisors(nominator);
            var denominatorDivisors = Divisors(denominator);
            var comomon = nominatorDivisors.Intersect(denominatorDivisors);

            foreach (var divisor in comomon)
            {
                nominator /= divisor;
                denominator /= divisor;
            }

            _nominator = nominator;
            _denominator = denominator;
        }

        public static Rational Inverse(Rational rational)
        {
            if (rational.Nominator == 0) { throw new System.DivideByZeroException(); }

            return new Rational(rational.Denominator, rational.Nominator);
        }

        public static Rational operator +(Rational a, Rational b)
        {
            if (a.Denominator == 1 && b.Denominator == 1)
            {
                return new Rational(a.Nominator + b.Nominator);
            }

            if (a.Denominator % b.Denominator == 0)
            {
                var ratio = (a.Denominator / b.Denominator);
                Rational newB = new Rational(b.Nominator * ratio, b.Denominator * ratio);
                return new Rational(a.Nominator + newB.Nominator, newB.Denominator);
            }
            else if (b.Denominator % a.Denominator == 0)
            {
                var ratio = (b.Denominator / a.Denominator);
                Rational newA = new Rational(a.Nominator * ratio, a.Denominator * ratio);
                return new Rational(newA.Nominator + b.Nominator, newA.Denominator);
            }
            else
            {
                return new Rational(a.Nominator * b.Denominator + b.Nominator * a.Denominator, a.Denominator * b.Denominator);
            }
        }

        public static Rational operator -(Rational a, Rational b)
        {
            b = new Rational(-b.Nominator, b.Denominator);
            return a + b;
        }

        public static Rational operator -(Rational a)
        {
            return new Rational(-a.Nominator, a.Denominator);
        }

        public static Rational operator *(Rational a, Rational b)
        {
            BigInteger nominator = a.Nominator * b.Nominator;
            BigInteger denominator = a.Denominator * b.Denominator;

            if (nominator % denominator == 0)
            {
                nominator /= denominator;
                denominator /= denominator;
            }

            if (denominator % nominator == 0)
            {
                denominator /= nominator;
                nominator /= nominator;
            }

            return new Rational(nominator, denominator);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            b = Inverse(b);
            return a * b;
        }

        public static void Test()
        {
            Rational a = new Rational(1, 2);
            Rational b = new Rational(2, 3);
            Rational c = new Rational(3, 2);

            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
            Console.WriteLine($"c = {c}");

            Console.WriteLine($"a + b = {a + b}");
            Console.WriteLine($"a - b = {a - b}");
            Console.WriteLine($"a + c = {a + c}");
            Console.WriteLine($"a - c = {a - c}");
            Console.WriteLine($"a * b = {a * b}");
            Console.WriteLine($"a / b = {a / b}");
            Console.WriteLine($"a * c = {a * c}");
            Console.WriteLine($"a / c = {a / c}");
        }

        public override string ToString()
        {
            return _nominator.ToString() + "/" + _denominator;
        }

        private static List<BigInteger> Divisors(BigInteger number)
        {
            List<BigInteger> properDivisors = new List<BigInteger>();

            if (number < 0) number = -number; // absolute value

            if (number == 1) return properDivisors;

            if (number == 2)
            {
                properDivisors.Add(2);
                return properDivisors;
            }

            for (BigInteger i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    properDivisors.Add(i);
                }
            }

            return properDivisors;
        }
    }
}