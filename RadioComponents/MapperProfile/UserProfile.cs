using AutoMapper;
using RadioComponents.Domain.Entities;
using RadioComponents.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.MapperProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, IndexViewModel>();
        }
    }
}
