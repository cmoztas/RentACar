namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult() : base(false, default)
        {
        }

        public ErrorDataResult(T data) : base(false, data)
        {
        }

        public ErrorDataResult(T data, string message) : base(false, message, data)
        {
        }

        public ErrorDataResult(string message) : base(false, message, default)
        {
        }
    }
}