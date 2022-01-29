using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RadioComponents.Domain;
using RadioComponents.Domain.Entities;
using RadioComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Services.Queries
{
    public class CategoryQueries
    {
        private readonly IMapper mapper;
        private readonly IRepository<Сategory> repository;

        public CategoryQueries(IMapper mapper, IRepository<Сategory> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<List<ListCategoryViewModel>> GetAllCategories()
        {
            var allcomponents = await repository.GetAll()
                     .ProjectTo<ListCategoryViewModel>(mapper.ConfigurationProvider)
                     .OrderBy(x => x.Id)
                     .ToListAsync();

            return allcomponents;
        }
    }
}
