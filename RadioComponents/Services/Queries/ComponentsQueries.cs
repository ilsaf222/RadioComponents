using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RadioComponents.Domain;
using RadioComponents.Domain.Entities;
using RadioComponents.Domain.Models;
using RadioComponents.Models.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Services.Queries
{
    public class ComponentsQueries
    {
        private readonly IRepository<Component> repository;
        private readonly IMapper mapper;

        public ComponentsQueries(IRepository<Component> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        public async Task<List<ListComponentViewModel>> GetAllComponents(string componName, ComponType? componType)
        {
            var query = repository.GetAll()
                .ProjectTo<ListComponentViewModel>(mapper.ConfigurationProvider);

            if (componName != null)
            {
                var normalComponName = componName.Trim().ToUpper();

                query = query.Where(x => x.ComponentName.ToUpper().Contains(normalComponName));
            }
            if(componType != null)
            {
                query = query.Where(x => x.Type == componType);
            }

            return await query
                .OrderBy(x => x.ComponentName)
                .ToListAsync();
        }
    }
}
