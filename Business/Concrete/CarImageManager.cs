using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.FileOperations;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImageDto carImage)
        {
            var result = BusinessRules.Run(CheckCarImagesCount(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            CarImage ci = new CarImage
            {
                CarId = carImage.CarId,
                ImagePath = FileOperation.WriteFile(carImage.ImagePath),
                Date = DateTime.Now
            };

            _carImageDal.Add(ci);
            return new SuccessResult(Messages.ImageAdded);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImageDto carImage)
        {
            var result = _carImageDal.Get(ci => ci.Id == carImage.Id);

            if (result == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            FileOperation.DeleteImageFile(result.ImagePath);

            _carImageDal.Delete(result);

            return new SuccessResult(Messages.ImageDeleted);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult DeleteAllByCarId(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);

            foreach (var item in result)
            {
                FileOperation.DeleteImageFile(item.ImagePath);
                _carImageDal.Delete(item);
            }
            return new SuccessResult(Messages.AllImageDeleted);
        }

        [PerformanceAspect(10)]
        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (result.Any())
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }

            return new SuccessDataResult<List<CarImage>>(new List<CarImage>
            {
                new CarImage{  CarId = carId,  ImagePath = "default.jpg", Date = DateTime.Now }
            });
        }

        [CacheAspect]
        public IDataResult<CarImage> GetById(int carImageId)
        {
            CarImage result = _carImageDal.Get(ci => ci.Id == carImageId);

            if (result == null)
            {
                return new ErrorDataResult<CarImage>(Messages.CarImageNotFound);
            }

            return new SuccessDataResult<CarImage>(result);
        }

        [SecuredOperation("admin")]
        public IResult Update(CarImageDto carImage)
        {
            var result = _carImageDal.Get(ci => ci.Id == carImage.Id);

            if (result == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            FileOperation.DeleteImageFile(result.ImagePath);
            result.ImagePath = FileOperation.WriteFile(carImage.ImagePath);
            result.Date = DateTime.Now;

            _carImageDal.Update(result);

            return new SuccessResult(Messages.ImageUpdated);
        }

        private IResult CheckCarImagesCount(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count;

            if (result >= 5)
            {
                return new ErrorResult(Messages.FileUploadAmountExceeded);
            }

            return new SuccessResult();
        }
    }
}