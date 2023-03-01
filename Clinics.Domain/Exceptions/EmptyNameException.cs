using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal sealed class EmptyNameException : DomainException
    {
        public EmptyNameException() : base("Name cannot be empty")
        {
        }
    }
}
