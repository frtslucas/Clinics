using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Exceptions;

namespace Clinics.Domain.Aggregates.PatientAggregate.ValueObjects
{
    public record PlaceOfBirth : ValueObject, IValueObject
    {
        public string Country { get; }

        public PlaceOfBirth(string country)
        {
            Guard.Against.NullOrEmpty<EmptyPlaceOfBirthException>(country);

            Country = country;
        }
    }
}
