using AutoMapper;
using RadioComponents.Models.Component;
using System.ComponentModel;
using Comp = RadioComponents.Domain.Entities.Component;

namespace RadioComponents.MapperProfile
{
    public class ComponentProfile : Profile
    {
        public ComponentProfile()
        {
            CreateMap<Comp, ListComponentViewModel>()
                   .ForMember(dest => dest.ComponentName, opt => opt.MapFrom(src => src.Category.Name))
                   .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Category.Image))
                   .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Category.Type));

        }
    }
}
