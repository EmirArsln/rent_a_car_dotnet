using Business.Abstract;
using Business.Constants;
using Business.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager(IRentalDal rentalDal) : IRentalService
    {
        readonly  IRentalDal _rentalDal = rentalDal;
        public IResult Add(Rental rental)
        {
            var result = CheckReturnDate(rental.CarId);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(result.Message);
        }

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetRentalDetails(c => c.CarId == carId && c.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.EntitiesListed);
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(c => c.CarId == carId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
        public IDataResult<byte[]> GetRentalDetailsExcel()
        {
            var rentals = GetAllRentalDetails().Data;
            var excelBytes = ExcelHelper.GenerateRentalExcel(rentals);
            return new SuccessDataResult<byte[]>(excelBytes, "Excel başarıyla oluşturuldu.");
        }
    }
}
