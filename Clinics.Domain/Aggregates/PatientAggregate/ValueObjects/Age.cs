using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Exceptions;

namespace Clinics.Domain.Aggregates.PatientAggregate.ValueObjects
{
    public record Age : ValueObject, IValueObject
    {
        public DateTime BirthDate { get; }
        public ushort CurrentAge { get => GetAge(); }

        public Age(DateTime birthDate)
        {
            Guard.Against.InvalidPastDateTime<InvalidBirthDateException>(birthDate);

            BirthDate = birthDate;
        }

        private Age() { }

        private ushort GetAge()
        {
            var age = DateTime.Now.Year - BirthDate.Year;

            if (BirthDate.Month < DateTime.Now.Month || BirthDate.Day < DateTime.Now.Day)
                age--;

            return (ushort)age;
        }

        public static Age FromDateTime(DateTime dateTime) => new(dateTime);
    }
}
