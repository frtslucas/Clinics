using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class EmptyStreetAddressException : DomainException
    {
        public EmptyStreetAddressException() : base("Street Address cannot be emtpy")
        {
        }
    }
}
