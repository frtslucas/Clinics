using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Exceptions;

namespace Clinics.Domain.Aggregates.PatientAggregate.ValueObjects
{
    public abstract record Document : ValueObject, IValueObject
    {
        protected readonly string _mask = null!;

        public string Value { get; } = null!;

        protected Document(string value, string mask, string propName, int maxLength, int? minLength = null)
        {
            Guard.Against.NullOrEmpty<EmptyDocumentException>(value);
            Guard.Against.InvalidLength(value, propName, maxLength, minLength);

            Value = value;
            _mask = mask;
        }

        protected Document() { }

        public string WithMask() => Value.Mask(_mask);
    }

    public record RG : Document
    {
        public RG(string value) : base(value, "##.###.###-#", nameof(RG), 9, 9)
        {
        }

        private RG() : base() { }

        public static RG FromString(string value) => new(value);
    }

    public record CPF : Document
    {
        public CPF(string value) : base(value, "###.###.###-##", nameof(CPF), 11, 11)
        {
        }

        private CPF() : base() { }

        public static CPF FromString(string value) => new(value);
    }
}
