using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using RadioComponents.MapperProfile;
using RadioComponents.Services.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Extensions
{
    public static class DependencyInjectionExtenstions
    {
        public static void AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CategoryProfile());
                mc.AddProfile(new ComponentProfile());
                mc.AddProfile(new OrderProfile());
                mc.AddProfile(new UserProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddQueries(this IServiceCollection services)
        {
            services.AddScoped<CategoryQueries>();
            services.AddScoped<ComponentsQueries>();
            services.AddScoped<OrderQueries>();
        }
    }
}
