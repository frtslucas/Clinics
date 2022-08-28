namespace Clinics.Domain.Abstractions
{
    public abstract class CustomException : Exception
    {
        protected CustomException()
        {
        }

        public CustomException(string message) : base(message)
        {
        }
    }
}
