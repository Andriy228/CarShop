using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Введіть ім'я")]
        [MinLength(5)]
        [Required(ErrorMessage = "Довжина ім'я не менше 5 символів")]
        public string Name { get; set; }
        [Display(Name = "Введіть фамілію")]
        [MinLength(5)]
        [Required(ErrorMessage = "Довжина фамілії не менше 5 символів")]
        public string SurName { get; set; }
        [Display(Name = "Введіть адресу")]
        [MinLength(5)]
        [Required(ErrorMessage = "Довжина адреси не менше 5 символів")]
        public string Adress { get; set; }
        [Display(Name = "Введіть номер телефону")]
        [DataType(DataType.PhoneNumber)]
        [MinLength(10)]
        [Required(ErrorMessage = "Довжина номера не менше 10 символів")]
        public string Phone { get; set; }
        [Display(Name = "Введіть email")]
        [DataType(DataType.EmailAddress)]
        [MinLength(15)]
        [Required(ErrorMessage = "Довжина email не менше 15 символів")]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
