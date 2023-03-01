using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class InvalidSessionIdForPacientException : DomainException
    {
        public InvalidSessionIdForPacientException() : base("The session given does not belong to the current pacient")
        {
        }
    }
}
