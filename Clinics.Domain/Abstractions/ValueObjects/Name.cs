using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Exceptions;

namespace Clinics.Domain.Abstractions.ValueObjects
{
    public abstract record Name : ValueObject, IValueObject
    {
        protected string Value { get; }

        public Name(string value)
        {
            Guard.Against.NullOrEmpty<EmptyNameException>(value);

            Value = value;
        }
    }
}
