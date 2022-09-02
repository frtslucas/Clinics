using Clinics.Domain.Abstractions;
using Clinics.Domain.Exceptions;

namespace Clinics.Domain.Guard
{
    public static class Against
    {
        public static void NullOrEmpty<TSource, TException>(IEnumerable<TSource>? values)
            where TException : CustomException, new()
        {
            if (values is null || !values.Any())
                throw new TException();
        }

        public static void NullOrEmpty<TException>(string value)
            where TException : CustomException, new()
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new TException();
        }

        public static void NullOrEmpty<TException>(Guid value)
            where TException : CustomException, new()
        {
            if (value == default)
                throw new TException();
        }

        public static void InvalidLength(string value, string propName, int maxLength, int? minLength = 0)
        {
            if (value.Length > maxLength || (minLength.HasValue && value.Length < minLength.Value))
                throw new InvalidLengthException(propName);
        }

        public static void NegativeOrZero<TException>(int value)
            where TException : CustomException, new()
        {
            if (value <= 0)
                throw new TException();
        }

        public static void Negative<TException>(decimal value)
            where TException : CustomException, new()
        {
            if (value < 0)
                throw new TException();
        }

        public static void InvalidPastDateTime<TException>(DateTime value)
            where TException : CustomException, new()
        {
            if (value > DateTime.UtcNow)
                throw new TException();
        }
    }
}
