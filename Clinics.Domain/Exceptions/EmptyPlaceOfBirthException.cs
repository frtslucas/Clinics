using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class EmptyPlaceOfBirthException : CustomException
    {
        public EmptyPlaceOfBirthException() : base("Place of Birth cannot be empty")
        {
        }
    }
}
