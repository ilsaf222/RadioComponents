using RadioComponents.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RadioComponents.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ComponentName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderTime { get; set; }
        public OrderStatus Status { get; set; }

        [Column(TypeName = "jsonb")]
        public string OrderInfoString { get; set; }
    }
}
