using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Exceptions;

namespace Clinics.Domain.Aggregates.PatientAggregate.ValueObjects
{
    public record Address : ValueObject, IValueObject
    {
        public string StreetAddress { get; }
        public int StreetNumber { get; }
        public string? ExtraLine { get; }
        public City City { get; }

        public Address(string streetAddress, int streetNumber, string? extraLine, string cityName, string state)
        {
            Guard.Against.NullOrEmpty<EmptyStreetAddressException>(streetAddress);
            Guard.Against.NegativeOrZero<InvalidStreetNumberException>(streetNumber);

            StreetAddress = streetAddress;
            StreetNumber = streetNumber;
            ExtraLine = extraLine;
            City = new City(cityName, state);
        }
    }
}
