using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class EmptyStateException : DomainException
    {
        public EmptyStateException() : base("State cannot be empty")
        {
        }
    }
}
