using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Exceptions;

namespace Clinics.Domain.Abstractions.ValueObjects
{
    public abstract record GuidIdentifier : ValueObject, IIdentifier<Guid>, IValueObject
    {
        public Guid Value { get; }

        protected GuidIdentifier()
        {
            Value = Guid.NewGuid();
        }

        protected GuidIdentifier(Guid value)
        {
            Guard.Against.NullOrEmpty<EmptyGuidIdentifierException>(value);

            Value = value;
        }
    }
}
