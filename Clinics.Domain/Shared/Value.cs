using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Exceptions;

namespace Clinics.Domain.Shared
{
    public record Value : ValueObject, IValueObject
    {
        public decimal Ammount { get; }

        public Value(decimal ammount)
        {
            Guard.Against.Negative<InvalidValueException>(ammount);

            Ammount = ammount;
        }

        private Value() { }

        public static Value Zero { get => new(0); }
        public static Value FromDecimal(decimal value) => new(value);
        public static Value Min(Value a, Value b) => new(Math.Min(a.Ammount, b.Ammount));

        public static Value operator +(Value a, Value b) => new(a.Ammount + b.Ammount);
        public static Value operator -(Value a, Value b) => new(a.Ammount - b.Ammount);
    }
}
