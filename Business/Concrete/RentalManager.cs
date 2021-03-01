using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.AllDatasListed);
        }

        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId), Messages.AllDatasListed);
        }

        public IDataResult<List<Rental>> GetAllByRentDateNewThan(DateTime rentDate)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.RentDate >= rentDate), Messages.AllDatasListed);
        }

        public IDataResult<List<Rental>> GetAllByRentDateOldThan(DateTime rentDate)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.RentDate <= rentDate), Messages.AllDatasListed);
        }

        public IDataResult<List<Rental>> GetAllByReturnDateNewThan(DateTime returnDate)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate >= returnDate), Messages.AllDatasListed);
        }

        public IDataResult<List<Rental>> GetAllByReturnDateOldThan(DateTime returnDate)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate <= returnDate), Messages.AllDatasListed);
        }

        public IDataResult<List<RentalDetailDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsDetail(), Messages.AllDatasListed);
        }

        public IDataResult<Rental> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CustomerId == customerId), Messages.AllDatasListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id), Messages.AllDatasListed);
        }
    }
}