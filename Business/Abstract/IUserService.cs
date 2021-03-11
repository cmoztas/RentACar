using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);

        IDataResult<User> GetByEmail(string email);

        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}