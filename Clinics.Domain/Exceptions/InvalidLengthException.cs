using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class InvalidLengthException : DomainException
    {
        public InvalidLengthException(string propName) : base($"Property {propName} has invalid length")
        {
        }
    }
}
