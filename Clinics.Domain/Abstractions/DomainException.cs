namespace Clinics.Domain.Abstractions
{
    public abstract class DomainException : Exception
    {
        protected DomainException()
        {
        }

        public DomainException(string message) : base(message)
        {
        }
    }
}
