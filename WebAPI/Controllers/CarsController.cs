using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        [HttpGet]
        public List<Car> Get()
        {
            return new List<Car>
            {
                new Car{Id=1, BrandId=1,CalorId=1,DailyPrice=1,
                    Description= "Şehir içi kullanım için uygun",ModelYear=2017},
                new Car{Id=2, BrandId=2,CalorId=2,DailyPrice=2,
                    Description= "Arazide kullanı   m için uygun",ModelYear=2013}
            };
        }
    }
}
