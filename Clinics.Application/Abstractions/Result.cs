namespace Clinics.Application.Abstractions
{
    public record Result
    {
        public bool IsValid { get; }
        public Error? Error { get; }
        public string? Message { get; }

        private Result(bool isValid, Error? error = null, string? message = null)
        {
            IsValid = isValid;
            Error = error;
            Message = message;
        }

        public static Result Success = new(true);
        public static Result Fail(Error error, string? message = null) => new(false, error, message);
    }
}
