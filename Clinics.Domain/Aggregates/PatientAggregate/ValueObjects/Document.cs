using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Exceptions;

namespace Clinics.Domain.Aggregates.PatientAggregate.ValueObjects
{
    public abstract record Document : ValueObject, IValueObject
    {
        protected readonly string _mask;

        public string Value { get; }

        protected Document(string value, string mask, string propName, int maxLength, int? minLength = null)
        {
            Guard.Against.NullOrEmpty<EmptyDocumentException>(value);
            Guard.Against.InvalidLength(value, propName, maxLength, minLength);

            Value = value;
            _mask = mask;
        }

        public string WithMask() => Value.Mask(_mask);
    }

    public record RG : Document
    {
        public RG(string value) : base(value, "##.###.###-#", nameof(RG), 9, 9)
        {
        }
    }

    public record CPF : Document
    {
        public CPF(string value) : base(value, "###.###.###-##", nameof(CPF), 11, 11)
        {
        }
    }
}
