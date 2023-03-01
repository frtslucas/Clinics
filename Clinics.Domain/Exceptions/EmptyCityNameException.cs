using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class EmptyCityNameException : DomainException
    {
        public EmptyCityNameException() : base("City Name cannot be empty")
        {
        }
    }
}
