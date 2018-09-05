using System.Numerics;

namespace Common
{
    public struct Rational
    {
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

            _nominator = nominator;
            _denominator = denominator;
        }

        public Rational Inverse(Rational rational)
        {
            if (rational.Nominator == 0) { throw new System.DivideByZeroException(); }

            return new Rational(rational.Denominator, rational.Nominator);
        }
    }
}