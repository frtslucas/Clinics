namespace Clinics.Application.Abstractions
{
    public record Result
    {
        public bool IsValid { get; }
        public Error? Error { get; }
        public string? Message { get; }

        protected Result(bool isValid, Error? error = null, string? message = null)
        {
            IsValid = isValid;
            Error = error;
            Message = message;
        }

        public static Result Success = new(true);
        public static Result Fail(Error error, string? message = null) => new(false, error, message);
    }

    public record Result<TReturnValue> : Result
    {
        public TReturnValue ReturnValue { get; }

        private Result(bool isValid, TReturnValue returnValue = default, Error? error = null, string? message = null) : base(isValid, error, message)
        {
            ReturnValue = returnValue;
        }

        public static Result<TReturnValue> SuccessWithValue(TReturnValue returnValue) => new(true, returnValue);
        public static new Result<TReturnValue> Fail(Error error, string? message = null) => new(false, default, error, message);
    }
}
