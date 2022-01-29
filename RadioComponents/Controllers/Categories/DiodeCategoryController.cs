using Microsoft.AspNetCore.Hosting;
using RadioComponents.Domain;
using RadioComponents.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Controllers.Categories
{
    public class DiodeCategoryController : CategoryGenericController<DiodeCategoryController>
    {
        public DiodeCategoryController(IRepository<Сategory> repository, IWebHostEnvironment environment) : base(repository, environment)
        {
        }
    }
}
