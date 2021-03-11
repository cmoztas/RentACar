using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        private IDataResult<User> userToCheck;
        private object successfulLogin;

        public SuccessDataResult() : base(true, default)
        {
        }

        public SuccessDataResult(T data) : base(true, data)
        {
        }

        public SuccessDataResult(T data, string message) : base(true, message, data)
        {
        }

        public SuccessDataResult(string message) : base(true, message, default)
        {
        }
    }
}