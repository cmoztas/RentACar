using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);

        IResult Update(Customer customer);

        IResult Delete(Customer customer);

        IDataResult<Customer> GetById(int id);

        IDataResult<Customer> GetByUserId(int id);

        IDataResult<Customer> GetByCompanyName(string companyName);

        IDataResult<List<Customer>> GetAll();

        IDataResult<List<CustomerDetailDto>> GetAllDetails();
    }
}