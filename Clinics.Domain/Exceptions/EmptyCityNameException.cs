using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class EmptyCityNameException : CustomException
    {
        public EmptyCityNameException() : base("City Name cannot be empty")
        {
        }
    }
}
