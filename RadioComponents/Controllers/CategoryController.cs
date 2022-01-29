using Microsoft.AspNetCore.Mvc;
using RadioComponents.Domain;
using RadioComponents.Domain.Entities;
using RadioComponents.Domain.Models;
using RadioComponents.Services.Queries;
using System.Threading.Tasks;

namespace RadioComponents.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Сategory> repository;
        private readonly CategoryQueries categoryQueries;

        public CategoryController(IRepository<Сategory> repository, CategoryQueries categoryQueries)
        {
            this.repository = repository;
            this.categoryQueries = categoryQueries;
        }

        public async Task<IActionResult> List()
        {
            var categories = await categoryQueries.GetAllCategories();
            return View(categories);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await repository.GetByIdAsync(id);

            return category.Type switch
            {
                ComponType.Resistor => RedirectToAction("Edit", "ResistorCategory", new { id = id }),
                ComponType.Сapacitor => RedirectToAction("Edit", "СapacitorCategory", new { id = id }),
                _ => RedirectToAction("List")
            };
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await repository.GetByIdAsync(id);

            await repository.RemoveAsync(category);

            return RedirectToAction("List");
        }

        public async Task<IActionResult> Info(int id) 
        {
            var category = await repository.GetByIdAsync(id);

            return category.Type switch
            {
                ComponType.Resistor => RedirectToAction("Info", "ResistorCategory", new { id = id }),
                ComponType.Сapacitor => RedirectToAction("Info", "СapacitorCategory", new { id = id }),
                _ => RedirectToAction("List")
            };
        }
    }
}
