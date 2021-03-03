using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImageDto carImage);

        IResult Update(CarImageDto carImage);

        IResult Delete(CarImageDto carImage);

        IResult DeleteAllByCarId(int carId);

        IDataResult<List<CarImage>> GetAll();

        IDataResult<CarImage> GetById(int carImageId);

        IDataResult<List<CarImage>> GetAllByCarId(int carId);
    }
}