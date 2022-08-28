using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class EmptyOccupationException : CustomException
    {
        public EmptyOccupationException() : base("Occupation cannot be empty")
        {
        }
    }
}
