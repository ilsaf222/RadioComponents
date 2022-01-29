using RadioComponents.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Models.Component
{
    public class ListComponentViewModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public ComponType Type { get; set; } 
        public int CategoryId { get; set; }

        [Display(Name = "Цена")]
        public int Price { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        [Display(Name = "Название")]
        public string ComponentName { get; set; }
    }
}
