using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);

        IResult Update(Rental rental);

        IResult Delete(Rental rental);

        IDataResult<Rental> GetById(int id);

        IDataResult<Rental> GetByCustomerId(int customerId);

        IDataResult<List<Rental>> GetAll();

        IDataResult<List<Rental>> GetAllByCarId(int carId);

        IDataResult<List<Rental>> GetAllByRentDateNewThan(DateTime rentDate);

        IDataResult<List<Rental>> GetAllByRentDateOldThan(DateTime rentDate);

        IDataResult<List<Rental>> GetAllByReturnDateNewThan(DateTime returnDate);

        IDataResult<List<Rental>> GetAllByReturnDateOldThan(DateTime returnDate);

        IDataResult<List<RentalDetailDto>> GetAllDetails();
    }
}