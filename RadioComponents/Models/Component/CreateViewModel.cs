using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Models.Component
{
    public class CreateViewModel
    {
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int? CategoryId { get; set; }
    }
}
