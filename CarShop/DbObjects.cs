using CarShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarShop
{
    public class DbObjects
    {
        public static void Initial(AppDbContext content)
        {
            if (!content.Categories.Any())
                content.Categories.AddRange(Categories.Select(c=>c.Value));
            if (!content.Cars.Any())
            {
                content.Cars.AddRange(
                    new Car
                    {
                        Name = "Tesla Model S",
                        ShortDesc = "Fast automobile",
                        LongDesc = "A nice, fast and very quiet Tesla car",
                        Img = "/img/tesla.jpg",
                        Price = 45000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Електромобілі"]
                    },
                     new Car
                     {
                         Name = "Ford Fiesta",
                         ShortDesc = "Quiet and peaceful",
                         LongDesc = "Сomfortable car for city life",
                         Img = "/img/ford-fiesta.jpg",
                         Price = 11000,
                         IsFavourite = false,
                         Available = true,
                         Category = Categories["Класичні автомобілі"]
                     },
                     new Car
                     {
                         Name = "BMW M3",
                         ShortDesc = "Gangst and styles",
                         LongDesc = "Comfortable car for cities life",
                         Img = "/img/BMW-M3.jpg",
                         Price = 65000,
                         IsFavourite = true,
                         Available = true,
                         Category = Categories["Класичні автомобілі"]
                     },
                     new Car
                     {
                         Name = "Mercedes C class",
                         ShortDesc = "Сomfortable and great",
                         LongDesc = "Comfortable car for cities life",
                         Img = "/img/Mercedes.jpg",
                         Price = 40000,
                         IsFavourite = false,
                         Available = true,
                         Category = Categories["Класичні автомобілі"]
                     },
                     new Car
                     {
                         Name = "Nissan Leaf",
                         ShortDesc = "Silent and economical",
                         LongDesc = "Comfortable car for cities life",
                         Price = 14000,
                         Img = "/img/Nissan-Leaf.jpg",
                         IsFavourite = true,
                         Available = true,
                         Category = Categories["Електромобілі"]
                     }
                );
            }
            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string,Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                         new Category{ CategoryName = "Електромобілі", Description = "Сучасний вид транспорту"},
                         new Category{CategoryName = "Класичні автомобілі",Description = "Автомобілі з двигуном внутрішнього згорання" }
                    };

                    category = new Dictionary<string, Category>();

                    foreach (Category el in list)
                    {
                        category.Add(el.CategoryName,el);
                    }
                }
                return category;
            }
        }
    }
}
