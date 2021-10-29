using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CalorManager : ICalorService
    {

        ICalorDal _calorDal;

        public CalorManager(ICalorDal calorDal)
        {
            _calorDal = calorDal;
        }
        public IResult Add(Calor calor)
        {
            _calorDal.Add(calor);
            return new SuccessResult();
        }

        public IResult Delete(Calor calor)
        {
            _calorDal.Delete(calor);
            return new SuccessResult();
        }

        public IDataResult<List<Calor>> GetAll()
        {
            return new SuccessDataResult<List<Calor>>(_calorDal.GetAll());
        }

        public IDataResult<Calor> GetById(int Id)
        {
            return new SuccessDataResult<Calor>(_calorDal.Get(c=> c.Id == Id));
        }

        public IResult Update(Calor calor)
        {
            _calorDal.Update(calor);
            return new SuccessResult();
        }
    }
}
