using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public  class RentACarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CarRental;Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Calor> Calors { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
