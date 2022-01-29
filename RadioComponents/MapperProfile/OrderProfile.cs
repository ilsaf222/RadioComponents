using AutoMapper;
using RadioComponents.Domain.Entities;
using RadioComponents.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.MapperProfile
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, ListOrderViewModel>();
        }
    }
}
