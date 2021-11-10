using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;
        FileHelper _fileHelper;


        public ImageManager(IImageDal imageDal, FileHelper fileHelper)
        {
            _imageDal = imageDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile file, Image carImage)
        {
            var imageCount = _imageDal.GetAll(c => c.CarId == carImage.CarId).Count();
            if (imageCount >= 5)
            {
                return new ErrorResult("You can have maximum five image!");
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _imageDal.Add(carImage);
            return new SuccessResult("Photo upload successfully<3");
        }

        public IResult Delete(Image carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _imageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_imageDal.Get(c => c.Id == imageId));
        }


        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll());
        }

        public IDataResult<Image> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<Image>(_imageDal.Get(c => c.Id == id));
        }

        public IResult Update(IFormFile file, Image carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _imageDal.Update(carImage);
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {

            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImage);

        }
        private IResult CheckCarImage(int carId)
        {
            var result = _imageDal.GetAll(c => c.CarId == carId).Count();
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

    }
}