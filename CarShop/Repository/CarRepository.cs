using CarShop.Interfaces;
using CarShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDbContext appDbContext;

        public CarRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Car> AllCars => appDbContext.Cars.Include(c => c.Category);

        public IEnumerable<Car> getFavCars => appDbContext.Cars.Where(p => p.IsFavourite).Include(c => c.Category);

        public Car GetObjCar(int CarId) => appDbContext.Cars.FirstOrDefault(p=>p.Id == CarId);
    }
}
