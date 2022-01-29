using Microsoft.AspNetCore.Hosting;
using RadioComponents.Domain;
using RadioComponents.Domain.Entities;
using RadioComponents.Models.CategoryViewModels.Resistor;

namespace RadioComponents.Controllers.Categories
{
    public class ResistorCategoryController : CategoryGenericController<ResistorCategoryViewModel>
    {
        public ResistorCategoryController(IRepository<Сategory> repository, IWebHostEnvironment environment) : base(repository, environment)
        {
        }
    }
}
