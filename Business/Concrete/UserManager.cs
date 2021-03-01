using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.AllDatasListed);
        }

        public IDataResult<List<User>> GetAllByFirstName(string firstName)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.FirstName == firstName), Messages.AllDatasListed);
        }

        public IDataResult<List<User>> GetAllByLastName(string lastName)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.LastName == lastName), Messages.AllDatasListed);
        }

        public IDataResult<List<User>> GetAllByPassword(string password)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Password == password), Messages.AllDatasListed);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email), Messages.AllDatasListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), Messages.AllDatasListed);
        }
    }
}