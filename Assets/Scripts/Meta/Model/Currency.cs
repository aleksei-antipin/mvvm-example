using System;

namespace Test.Meta
{
    public sealed class Currency
    {
        public Currency(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public override string ToString()
        {
            return $"Currency. Name: {Id}, Id: {Name}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Currency currency) return Equals(currency);

            return false;
        }

        private bool Equals(Currency other)
        {
            return Id == other.Id && Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }

        public static bool operator ==(Currency a, Currency b)
        {
            return a != null && b != null && a.Equals(b);
        }

        public static bool operator !=(Currency a, Currency b)
        {
            return !(a == b);
        }
    }
}