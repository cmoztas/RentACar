using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);

        IResult Update(User user);

        IResult Delete(User user);

        IDataResult<User> GetById(int id);

        IDataResult<User> GetByEmail(string email);

        IDataResult<List<User>> GetAll();

        IDataResult<List<User>> GetAllByFirstName(string firstName);

        IDataResult<List<User>> GetAllByLastName(string lastName);

        IDataResult<List<User>> GetAllByPassword(string password);
    }
}