using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class InvalidStreetNumberException : DomainException
    {
        public InvalidStreetNumberException() : base("Invalid Street Number, must greater than zero")
        {
        }
    }
}
