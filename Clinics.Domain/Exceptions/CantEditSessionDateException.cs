using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class CantEditSessionDateException : DomainException
    {
        public CantEditSessionDateException() : base("Can't edit Session date because Session has already been done")
        {
        }
    }
}
