using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<RentACarContext, Customer>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomersDetail()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.Id
                             orderby c.Id ascending
                             select new CustomerDetailDto()
                             {
                                 Id = c.Id,
                                 CompanyName = c.CompanyName,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 Email = u.Email
                             };

                return result.ToList();
            }
        }
    }
}