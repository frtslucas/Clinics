using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    public class InvalidSessionDateException : DomainException
    {
        public InvalidSessionDateException(string message = "Invalid date for session") : base(message)
        {
        }
    }
}
