using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class InvalidPaymentException : CustomException
    {
        public InvalidPaymentException() : base("Invalid Payment, the sum of all Session payments cannot be greater than the value of the Session")
        {
        }
    }
}
