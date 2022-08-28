using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class InvalidBirthDateException : CustomException
    {
        public InvalidBirthDateException() : base("Invalid Birth Date, must not be greater than today")
        {
        }
    }
}
