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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter)
            {
            using RentCarContext context = new();

            var result = from c in filter is null ? context.Cars : context.Cars.Where(filter)
                         join b in context.Brands
                         on c.BrandId equals b.BrandId
                         join co in context.Colors
                         on c.ColorId equals co.ColorId

                         select new CarDetailDto
                         {
                             CarId = c.CarId,
                             BrandName = b.BrandName,
                             ColorName = co.ColorName,
                             CarName = c.CarName,
                             ModelYear = c.ModelYear,
                             Description = c.Description,
                             DailyPrice = (int)c.DailyPrice,
                             //  ImagePath = (from img in context.CarImages
                             //             where img.CarId == c.CarId
                             //           select img.ImagePath).FirstOrDefault()


                             //ImagePath = img.ImagePath == null ? "Image Not Found" : img.ImagePath
                         };

            return [.. result];
        }
        }

   
}