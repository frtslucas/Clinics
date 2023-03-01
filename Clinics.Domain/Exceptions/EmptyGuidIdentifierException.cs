using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class EmptyGuidIdentifierException : DomainException
    {
        public EmptyGuidIdentifierException() : base("Guid Identifier cannot be an empty Guid")
        {
        }
    }
}
