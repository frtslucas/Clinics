using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class EmptyGuidIdentifierException : CustomException
    {
        public EmptyGuidIdentifierException() : base("Guid Identifier cannot be an empty Guid")
        {
        }
    }
}
