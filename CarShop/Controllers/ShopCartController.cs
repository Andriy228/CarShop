using System.Linq;
using CarShop.Interfaces;
using CarShop.Models;
using CarShop.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace CarShop.Controllers
{
    public class ShopCartController : Controller
    {
        private  IAllCars _carRep;
        private readonly ShopCart _shopCart;
       
        public ShopCartController(IAllCars _carRep, ShopCart _shopCart)
        {
            this._carRep = _carRep;
            this._shopCart = _shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.AllCars.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
