using RadioComponents.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ord = RadioComponents.Domain.Entities.Order;

namespace RadioComponents.Models.Order
{
    public class ListOrderViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Клиент")]
        public string ClientName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }

        [Display(Name = "Компонент")]
        public string ComponentName { get; set; }

        [Display(Name = "Время заказа")]
        public DateTime OrderTime { get; set; }

        [Display(Name = "Итоговая цена:")]
        public int TotalPrice { get; set; }
        public List<Ord> AllOrders { get; set; }
    }
}
