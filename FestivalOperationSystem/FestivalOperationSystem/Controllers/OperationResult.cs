namespace FestivalOperationSystem.Controllers
{
    /// <summary>
    /// What the Controller sends back to a form: whether the action worked and a message to show.
    /// Forms check <see cref="Success"/> instead of catching exceptions themselves.
    /// </summary>
    public class OperationResult
    {
        protected OperationResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; }
        public string Message { get; }

        public static OperationResult Ok(string message = "")
        {
            return new OperationResult(true, message);
        }

        public static OperationResult Fail(string message)
        {
            return new OperationResult(false, message);
        }
    }

    /// <summary>
    /// An <see cref="OperationResult"/> that also carries a value, e.g. the list of people or a new ID.
    /// <see cref="Value"/> is only meaningful when <see cref="OperationResult.Success"/> is true.
    /// </summary>
    public class OperationResult<T> : OperationResult
    {
        private OperationResult(bool success, string message, T value)
            : base(success, message)
        {
            Value = value;
        }

        public T Value { get; }

        public static OperationResult<T> Ok(T value, string message = "")
        {
            return new OperationResult<T>(true, message, value);
        }

        public static new OperationResult<T> Fail(string message)
        {
            return new OperationResult<T>(false, message, default!);
        }
    }
}
