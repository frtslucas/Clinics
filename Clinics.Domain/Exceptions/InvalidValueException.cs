using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class InvalidValueException : DomainException
    {
        public InvalidValueException() : base("Invalid value")
        {
        }
    }
}
