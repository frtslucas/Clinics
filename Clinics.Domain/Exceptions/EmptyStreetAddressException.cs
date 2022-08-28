using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class EmptyStreetAddressException : CustomException
    {
        public EmptyStreetAddressException() : base("Street Address cannot be emtpy")
        {
        }
    }
}
