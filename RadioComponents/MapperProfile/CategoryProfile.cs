using AutoMapper;
using RadioComponents.Domain.Entities;
using RadioComponents.Models;

namespace RadioComponents.MapperProfile
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Сategory, ListCategoryViewModel>();
        }
    }
}
