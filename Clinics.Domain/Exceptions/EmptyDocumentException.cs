using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class EmptyDocumentException : CustomException
    {
        public EmptyDocumentException() : base("Document cannot be empty")
        {
        }
    }
}
