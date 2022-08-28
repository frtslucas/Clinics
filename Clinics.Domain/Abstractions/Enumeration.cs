using System.Reflection;

namespace Clinics.Domain.Abstractions
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }
        public int Value { get; private set; }

        protected Enumeration(int value, string name) => (Value, Name) = (value, name);

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                        .Select(f => f.GetValue(null))
                        .Cast<T>();

        public override bool Equals(object? obj)
        {
            if (obj is not Enumeration otherValue)
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
            return absoluteDifference;
        }

        public static T FromValue<T>(Enum @enum)
            where T : Enumeration
        {
            return FromValue<T>(Convert.ToInt32(@enum));
        }

        public static T FromValue<T>(int value)
            where T : Enumeration
        {
            var matchingItem = Parse<T, int>(value, "value", item => item.Value == value);
            return matchingItem;
        }

        public static T FromName<T>(string name)
            where T : Enumeration
        {
            var matchingItem = Parse<T, string>(name, "name", item => item.Name == name);
            return matchingItem;
        }

        private static T Parse<T, K>(K value, string name, Func<T, bool> predicate)
            where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
                throw new InvalidOperationException($"'{value}' is not a valid {name} in {typeof(T)}");

            return matchingItem;
        }

        public int CompareTo(object? other)
        {
            if (other is null)
                throw new NullReferenceException(nameof(other));

            return Value.CompareTo(((Enumeration)other).Value);
        }
    }
}
