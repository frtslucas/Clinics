using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Exceptions;

namespace Clinics.Domain.Aggregates.PatientAggregate.ValueObjects
{
    public record City : ValueObject, IValueObject
    {
        public string CityName { get; }
        public string State { get; }

        internal City(string cityName, string state)
        {
            Guard.Against.NullOrEmpty<EmptyCityNameException>(cityName);
            Guard.Against.NullOrEmpty<EmptyStateException>(state);

            CityName = cityName;
            State = state;
        }
    }
}
