using Business.Abstract;
using Business.BusinessAspects.Autofact;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.AutoFac.Caching;
using Core.Aspect.AutoFac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager(ICarDal carDal) : ICarService
    {
       private readonly ICarDal _carDal = carDal;


       [SecuredOperation("admin")]
       [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
      
        public IDataResult<Car> GetById(int carId)
        {

            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == carId));

        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => true));
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour >= 02 && DateTime.Now.Hour <= 03)
            {
                return new ErrorDataResult<List<Car>>();
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => true), Messages.EntitiesListed);



           
        }

            public IResult Update(Car car)
            {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
            }
    }
}
