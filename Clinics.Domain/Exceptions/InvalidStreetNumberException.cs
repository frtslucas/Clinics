using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class InvalidStreetNumberException : CustomException
    {
        public InvalidStreetNumberException() : base("Invalid Street Number, must greater than zero")
        {
        }
    }
}
