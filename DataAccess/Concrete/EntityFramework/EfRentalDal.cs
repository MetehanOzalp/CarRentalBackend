using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MyDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (MyDbContext context = new MyDbContext())
            {
                var result = from re in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join car in context.Cars on re.CarId equals car.Id
                             join customer in context.Customers on re.CustomerId equals customer.Id
                             join user in context.Users on customer.UserId equals user.Id
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             select new RentalDetailDto
                             {
                                 Id = re.Id,
                                 BrandName = brand.BrandName,
                                 CarName = car.CarName,
                                 CustomerName = customer.CompanyName,
                                 CarId = car.Id,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,
                                 UserName = user.FirstName + " " + user.LastName
                             };
                return result.ToList();
            }
        }
    }
}
