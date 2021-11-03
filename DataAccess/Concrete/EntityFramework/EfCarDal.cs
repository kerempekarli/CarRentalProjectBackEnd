using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDtos()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in context.Cars
                             join c in context.Calors
                             on car.CalorId equals c.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id

                             select new CarDetailDto
                             {
                                 ProductId = car.Id,
                                 CalorName = c.CalorName,
                                 BrandName = brand.Name,
                                 ModelYear = car.ModelYear
                             };
                         return result.ToList();
            }

        }
    }
}
