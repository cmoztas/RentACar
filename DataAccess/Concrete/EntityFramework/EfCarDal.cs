using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<RentACarContext, Car>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetail()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             orderby c.Id ascending
                             select new CarDetailDto()
                             {
                                 Id = c.Id,
                                 Brand = b.Name,
                                 Color = cl.Name,
                                 Model = c.Model,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice
                             };

                return result.ToList();
            }
        }
    }
}