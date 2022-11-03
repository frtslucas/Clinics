using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Clinics.Domain.Shared
{
    public record MoneyValue : ValueObject, IValueObject
    {
        public decimal Value { get; }

        public MoneyValue(decimal value)
        {
            Guard.Against.Negative<InvalidMoneyValueException>(value);

            Value = value;
        }

        private MoneyValue() { }

        public static MoneyValue FromDecimal(decimal value) => new(value);
    }
}
