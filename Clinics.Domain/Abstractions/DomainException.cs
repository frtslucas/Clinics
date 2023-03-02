namespace Clinics.Domain.Abstractions
{
    public class DomainException : Exception
    {
        protected DomainException()
        {
        }

        public DomainException(string message) : base(message)
        {
        }
    }
}
