using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> AllCars { get; }
        IEnumerable<Car> getFavCars { get; }
        Car GetObjCar(int CarId);
    }
}
