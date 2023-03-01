using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class EmptyDocumentException : DomainException
    {
        public EmptyDocumentException() : base("Document cannot be empty")
        {
        }
    }
}
