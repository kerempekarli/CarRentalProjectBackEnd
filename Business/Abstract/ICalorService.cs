using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICalorService
    {
        IDataResult<Calor> GetById(int Id);
        IDataResult<List<Calor>> GetAll();
        IResult Add(Calor calor);
        IResult Update(Calor calor);
        IResult Delete(Calor calor);
    }
}
