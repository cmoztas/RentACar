using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        [SecuredOperation("admin")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.AllDatasListed);
        }

        [CacheAspect]
        public IDataResult<List<CustomerDetailDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomersDetail(), Messages.AllDatasListed);
        }

        public IDataResult<Customer> GetByCompanyName(string companyName)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CompanyName == companyName), Messages.AllDatasListed);
        }

        [CacheAspect]
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id), Messages.AllDatasListed);
        }

        public IDataResult<Customer> GetByUserId(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserId == id), Messages.AllDatasListed);
        }
    }
}