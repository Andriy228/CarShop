using CarShop.Interfaces;
using CarShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDbContext context;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDbContext context, ShopCart shopCart)
        {
            this.context = context;
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            context.Orders.Add(order);

            var items = shopCart.ListShopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = el.Car.Id,
                    OrderId = order.Id,
                    Price = el.Car.Price
                };
                context.OrderDetails.Add(orderDetail);
            }
            context.SaveChanges();
        }
    }
}
