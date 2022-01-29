using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ord = RadioComponents.Domain.Entities.Order;

namespace RadioComponents.Models.Order
{
    public class ListMyOrderViewModel
    {
        public List<Ord> AllOrders { get; set; }
    }
}
