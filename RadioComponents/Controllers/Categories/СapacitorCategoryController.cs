using Microsoft.AspNetCore.Hosting;
using RadioComponents.Domain;
using RadioComponents.Domain.Entities;
using RadioComponents.Models.CategoryViewModels.Capacitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Controllers.Categories
{
    public class СapacitorCategoryController : CategoryGenericController<СapacitorCategoryViewModel>
    {
        public СapacitorCategoryController(IRepository<Сategory> repository, IWebHostEnvironment environment) :base(repository, environment)
        {

        }
    }
}
