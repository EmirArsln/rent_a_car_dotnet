using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from rental in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join cars in context.Cars
                             on rental.CarId equals cars.CarId
                             join user in context.Users
                             on rental.UserId equals user.UserId
                             join color in context.Colors
                             on cars.ColorId equals color.ColorId
                             join brand in context.Brands
                             on cars.BrandId equals brand.BrandId
                             select new RentalDetailDto
                             {
                                 RentalId = rental.RentalId,
                                 UserId = user.UserId,
                                 CarId = cars.CarId,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = cars.DailyPrice,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 ModelYear = cars.ModelYear,
                                 Description = cars.Description,
                                 Gear = cars.Gear,
                                 Speed = cars.Speed,
                                 Seats = cars.Seats,
                                 FuelType = cars.FuelType,


                             };

                return result.ToList();


            }
        }
    }
}
