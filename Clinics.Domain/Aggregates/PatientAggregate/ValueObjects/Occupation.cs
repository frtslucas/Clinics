using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Exceptions;

namespace Clinics.Domain.Aggregates.PatientAggregate.ValueObjects
{
    public record Occupation : ValueObject, IValueObject
    {
        public string Value { get; } = null!;

        public Occupation(string value)
        {
            Guard.Against.NullOrEmpty<EmptyOccupationException>(value);

            Value = value;
        }

        private Occupation() { }

        public static Occupation FromString(string occupation) => new(occupation);
    }
}
