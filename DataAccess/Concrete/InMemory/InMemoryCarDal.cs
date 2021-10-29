using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
             new Car{Id = 1, BrandId = 1, CalorId =1, ModelYear = 2000, DailyPrice = 200, Description = "Konforlu ve az yakıyor. Şehir içi kullanım için ideal" },
             new Car{Id = 2, BrandId = 2, CalorId =2, ModelYear = 2000, DailyPrice = 200, Description = "Konforlu ve az yakıyor. Şehir içi kullanım için ideal" },
             new Car { Id = 3, BrandId = 3, CalorId = 3, ModelYear = 2000, DailyPrice = 200, Description = "Konforlu ve az yakıyor. Şehir içi kullanım için ideal" },
             new Car { Id = 4, BrandId = 4, CalorId = 4, ModelYear = 4, DailyPrice = 200, Description = "Konforlu ve az yakıyor. Şehir içi kullanım için ideal" }
        };

        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {

            _cars.Remove(_cars.SingleOrDefault(p => p.Id == car.Id));
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.CalorId = car.CalorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
    }
}

