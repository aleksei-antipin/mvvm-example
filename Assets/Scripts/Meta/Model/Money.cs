using System.Collections.Generic;
using System.Linq;

namespace Test.Meta
{
    public class Money
    {
        private readonly Dictionary<Currency, double> _values = new();
        public IReadOnlyDictionary<Currency, double> Values => _values;


        public override string ToString()
        {
            return _values.Aggregate("", (a, b) => a + " " + $"{b.Value} {b.Key.Name}");
        }

        private Money Clone()
        {
            var money = new Money(_values.ToDictionary(x => x.Key, y => y.Value));
            return money;
        }

        public void Add(Money money)
        {
            foreach (var value in money._values)
                if (!_values.TryAdd(value.Key, value.Value))
                    _values[value.Key] += value.Value;
        }

        public bool TrySpend(Money money)
        {
            var isCover = IsCover(money);
            if (isCover)
                foreach (var value in money._values)
                    _values[value.Key] -= value.Value;

            return isCover;
        }

        public bool IsCover(Money money)
        {
            foreach (var value in money._values)
                if (_values.TryGetValue(value.Key, out var amount))
                {
                    if (amount < value.Value)
                        return false;
                }
                else
                {
                    return false;
                }

            return true;
        }

        #region Operators

        public static Money operator +(Money a, Money b)
        {
            var money = a.Clone();

            foreach (var value in b._values)
                if (!money._values.TryAdd(value.Key, value.Value))
                    money._values[value.Key] += value.Value;

            return money;
        }

        public static bool operator ==(Money a, Money b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            if (a._values.Count != b._values.Count)
                return false;

            foreach (var aValue in a._values)
            {
                if (!b._values.TryGetValue(aValue.Key, out var amount)) return false;

                if (amount != aValue.Value)
                    return false;
            }

            return true;
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }

        #endregion

        #region Ctors

        public Money()
        {
            _values = new Dictionary<Currency, double>();
        }

        public Money(double amount, Currency currency)
        {
            _values.Add(currency, amount);
        }

        public Money(IDictionary<Currency, double> values)
        {
            _values = values.ToDictionary(x => x.Key, y => y.Value);
        }

        #endregion
    }
}