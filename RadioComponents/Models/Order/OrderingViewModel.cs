using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Models.Order
{
    public class OrderingViewModel
    {

        [Display(Name = "Клиент")]
        public string ClientName { get; set; }


        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }


        [Display(Name = "Время заказа")]
        public DateTime OrderTime { get; set; }
    }
}
