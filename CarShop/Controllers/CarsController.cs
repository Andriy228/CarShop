using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShop.Interfaces;
using CarShop.Models;
using CarShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private IAllCars allcars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars allcars, ICarsCategory _allCategories)
        {
            this.allcars = allcars;
            this._allCategories = _allCategories;
        }
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";

            if (string.IsNullOrEmpty(category))
            {
                cars = allcars.AllCars.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("elektro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = allcars.AllCars.Where(i => i.Category.CategoryName.Equals("Електромобілі")).OrderBy(i => i.Id);
                    currCategory = "Електромобілі";
                } else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = allcars.AllCars.Where(i => i.Category.CategoryName.Equals("Класичні автомобілі")).OrderBy(i => i.Id);
                    currCategory = "Класичні автомобілі";
                }
            }

            var carObj = new CarsListViewModel
            {
                AllCars = cars,
                carCategory = currCategory
            };

            ViewBag.Title = "Page with Automobiles";
           
            return View(carObj);
        }
    }
}
