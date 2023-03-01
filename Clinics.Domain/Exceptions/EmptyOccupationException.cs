using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class EmptyOccupationException : DomainException
    {
        public EmptyOccupationException() : base("Occupation cannot be empty")
        {
        }
    }
}
