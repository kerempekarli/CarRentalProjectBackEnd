using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        public static void Main(string[] args)
        {
            ICalorService calorService = new CalorManager(new EfCalorDal());
            
        }
    }
}
