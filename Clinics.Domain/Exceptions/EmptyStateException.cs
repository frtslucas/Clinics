using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class EmptyStateException : CustomException
    {
        public EmptyStateException() : base("State cannot be empty")
        {
        }
    }
}
