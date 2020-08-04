using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShop.Interfaces;
using CarShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        private IAllCars _carRep;
        public HomeController(IAllCars _carRep)
        {
            this._carRep = _carRep;
        }
        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                FavCars = _carRep.getFavCars
            };

            return View(homeCars);
        }
    }
}
