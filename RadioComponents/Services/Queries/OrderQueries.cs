using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RadioComponents.Domain;
using RadioComponents.Domain.Entities;
using RadioComponents.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Services.Queries
{
    public class OrderQueries
    {
        private readonly IRepository<Order> repository;
        private readonly IMapper mapper;

        public OrderQueries(IRepository<Order> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Queue<ListOrderViewModel>> GetAllOrders()
        {
            var orders = await repository.GetAll()
                .ProjectTo<ListOrderViewModel>(mapper.ConfigurationProvider)
                .OrderBy(x => x.ClientName).ToListAsync();

            var ordersqueue = new Queue<ListOrderViewModel>(orders);

            return ordersqueue;

        }
    }
}
