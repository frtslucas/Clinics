using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal sealed class EmptyNameException : CustomException
    {
        public EmptyNameException() : base("Name cannot be empty")
        {
        }
    }
}
