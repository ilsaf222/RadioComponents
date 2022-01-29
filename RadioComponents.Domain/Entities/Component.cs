using System;
using System.Collections.Generic;
using System.Text;

namespace RadioComponents.Domain.Entities
{
    public class Component
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int? CategoryId { get; set; }
        public Сategory Category { get; set; }
    }
}
