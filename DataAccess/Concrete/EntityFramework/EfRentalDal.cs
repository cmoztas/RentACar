using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using System.Collections.Generic;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<RentACarContext, Rental>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalsDetail()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join u in context.Users on cu.UserId equals u.Id
                             select new RentalDetailDto()
                             {
                                 Id = r.Id,
                                 CarBrand = b.Name,
                                 CarModel = c.Model,
                                 CustomerCompanyName = cu.CompanyName,
                                 CustomerName = u.FirstName,
                                 CustomerSurname = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();
            }
        }
    }
}