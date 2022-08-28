using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class InactivePacientException : CustomException
    {
        public InactivePacientException() : base("Pacient cannot be updated because they are inactive")
        {
        }
    }
}
