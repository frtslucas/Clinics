using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Exceptions;

namespace Clinics.Domain.Aggregates.PatientAggregate.ValueObjects
{
    public record Name : ValueObject, IValueObject
    {
        public string Value { get; } = null!;

        public Name(string value)
        {
            Guard.Against.NullOrEmpty<EmptyNameException>(value);

            Value = value;
        }

        public Name() { }

        public override string ToString() => Value;

        public static Name FromString(string name) => new(name);
    }
}
