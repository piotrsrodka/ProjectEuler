using System.Collections.Generic;

namespace Common
{
    public struct Size
    {
        private readonly double _value;
        private readonly List<KeyValuePair<StandardUnit, Rational>> _unit;

        public double Value { get { return _value; } }
        public List<KeyValuePair<StandardUnit, Rational>> Unit { get { return _unit; } }

        public Size(double value, StandardUnit standardUnit)
        {
            _value = value;
            _unit = new List<KeyValuePair<StandardUnit, Rational>>()
            {
                new KeyValuePair<StandardUnit, Rational>(standardUnit, new Rational(1))
            };
        }
    }
}
