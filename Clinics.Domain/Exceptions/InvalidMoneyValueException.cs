using Clinics.Domain.Abstractions;

namespace Clinics.Domain.Exceptions
{
    internal class InvalidMoneyValueException : CustomException
    {
        public InvalidMoneyValueException() : base("Invalid money value")
        {
        }
    }
}
