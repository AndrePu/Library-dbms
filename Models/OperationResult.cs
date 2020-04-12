namespace Models
{
    public class OperationResult
    {
        public OperationStatus status;
        public string message;

        public OperationResult(OperationStatus status, string message)
        {
            this.status = status;
            this.message = message;
        }

        public static OperationResult Error(string message)
        {
            return new OperationResult(OperationStatus.Error, message);
        }

        public static OperationResult Ok()
        {
            return new OperationResult(OperationStatus.Ok, null);
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T result;

        public OperationResult(OperationStatus status, string message, T result) : base(status, message)
        {
            this.result = result;
        }

        public static OperationResult<T> Ok(T result = default)
        {
            return new OperationResult<T>(OperationStatus.Ok, null, result);
        }

        public static OperationResult<T> Error(string message)
        {
            return new OperationResult<T>(OperationStatus.Error, message, default(T));
        }
    }
}
