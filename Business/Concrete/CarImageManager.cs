using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile[] file, CarImage carImage)
        {
            //IResult result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));
            //if (result != null)
            //{
            //    return result;
            //}
            foreach (var image in file)
            {
                carImage.ImagePath = FileHelper.Add(image);
                carImage.Date = DateTime.Now;
                carImage.Id = 0;
                _carImageDal.Add(carImage);

            }

            return new SuccessResult(Messages.CarImageAdded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int carId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.CarId == carId));
        }

        public IDataResult<List<CarImage>> GetAllImages()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(i => i.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckCarImageLimit(int carId)
        {
            var images = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (images >= 5)
            {
                return new ErrorResult(Messages.imageAdditionLimitExceeded);
            }
            return new SuccessResult();
        }

        private List<CarImage> CheckIfCarImageNull(int carId)
        {
            string path = @"images\defaultCar.png";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path.Replace("\\", "/"), Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == carId);
            //var result = _carImageDal.GetAll(i => i.CarId == carId).Any();
            //if (!result)
            //{
            //    List<CarImage> carImages = new List<CarImage>{
            //        new CarImage { CarId = carId, ImagePath =  @"\wwwroot\uploads\defaultCar.png", Date = DateTime.Now}
            //    };
            //    return carImages;
            //}
            //return _carImageDal.GetAll(i => i.CarId == carId);
        }

        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                FileHelper.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }
    }
}
