using Business.Abstract;
using Business.BusinessAspects.Autofact;
using Business.CCS;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{

    
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ILogger _logger;

        public CarManager(ICarDal carDal, ILogger logger)
        {
            _carDal = carDal;
            _logger = logger;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new Result(true, "Ürün eklendi");
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, "Ürün silindi");
        }

        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == Id));
        }

        public IDataResult<List<Car>> GetAll()
        {
           return new SuccessDataResult<List<Car>>( _carDal.GetAll(),"Ürünler getirildi.");
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos());
        }
    }
}
