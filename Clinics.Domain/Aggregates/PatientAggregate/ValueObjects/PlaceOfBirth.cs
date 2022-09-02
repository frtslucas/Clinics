using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Exceptions;

namespace Clinics.Domain.Aggregates.PatientAggregate.ValueObjects
{
    public record PlaceOfBirth : ValueObject, IValueObject
    {
        public string Country { get; } = null!;

        public PlaceOfBirth(string country)
        {
            Guard.Against.NullOrEmpty<EmptyPlaceOfBirthException>(country);

            Country = country;
        }

        private PlaceOfBirth() { }

        public static PlaceOfBirth FromString(string placeOfBirth) => new(placeOfBirth);
    }
}
