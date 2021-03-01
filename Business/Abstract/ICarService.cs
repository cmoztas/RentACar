using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);

        IResult Update(Car car);

        IResult Delete(Car car);

        IDataResult<Car> GetById(int id);

        IDataResult<List<Car>> GetAll();

        IDataResult<List<CarDetailDto>> GetAllDetails();

        IDataResult<List<Car>> GetAllByBrandId(int brandId);

        IDataResult<List<Car>> GetAllByColorId(int colorId);

        IDataResult<List<Car>> GetAllByModelYear(int modelYear);

        IDataResult<List<Car>> GetAllByModelYearGreaterThan(int modelYear);

        IDataResult<List<Car>> GetAllByModelYearLessThan(int modelYear);

        IDataResult<List<Car>> GetAllByDailyPriceGreaterThan(decimal price);

        IDataResult<List<Car>> GetAllByDailyPriceLessThan(decimal price);
    }
}