using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage, IFormFile formFile)
        {
            var result = BusinessRules.Run(
                CheckCarImageCount(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            var imageResult = FileHelper.Add(formFile);

            if (!imageResult.Success)
            {
                return new ErrorResult(Messages.ErrorMessage);
            }

            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.AddedMessage);
        }

        public IResult Delete(CarImage carImage)
        {
            var delete = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (carImage == null)
            {
                return new ErrorResult(Messages.ImageFound);
            }

            FileHelper.Delete(delete.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.DeletedMessage);
        }

        public IResult Update(CarImage carImage, IFormFile image)
        {
            var isImage = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (isImage == null)
            {
                return new ErrorResult(Messages.ImageFound);
            }

            var updated = FileHelper.Update(isImage.ImagePath, image);
            if (!updated.Success)
            {
                return new ErrorResult(updated.Message);
            }

            carImage.ImagePath = updated.Message;
            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.UpdatedMessage);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == carImageId));
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }

            List<CarImage> images = new List<CarImage>();
            images.Add(new CarImage() { CarId = 0, CarImageId = 0, ImagePath = "/images/default.jpg" });

            return new SuccessDataResult<List<CarImage>>(images);
        }

        //Business Rules

        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count > 4)
            {
                return new ErrorResult(Messages.ImageCount);
            }

            return new SuccessResult();
        }

    }
}
