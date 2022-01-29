using System;
using System.Collections.Generic;
using System.Text;

namespace RadioComponents.Domain.Entities
{
    public class Cart
    {
        public Component Component { get; set; }
        public int ComnpanentId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
