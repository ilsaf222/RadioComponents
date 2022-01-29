using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RadioComponents.Domain;
using RadioComponents.Domain.Entities;
using RadioComponents.Domain.Models;
using RadioComponents.Models.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Controllers
{
    public class ComponentController : Controller
    {
        private readonly IRepository<Component> repository;
        private readonly IRepository<Сategory> repCategory;
        private readonly IMapper mapper;

        public ComponentController(IRepository<Component> repository, IRepository<Сategory> repCategory, IMapper mapper)
        {
            this.repository = repository;
            this.repCategory = repCategory;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var allcomponents = await repository.GetAll()
                .ProjectTo<ListComponentViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            return View(allcomponents);
        }

        public async Task<IActionResult> Create()
        {
            var allcategories = await repCategory.GetAll()
                .ToListAsync();

            ViewBag.Categories = new SelectList(allcategories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            await repository.AddAsync(new Component()
            {
                Price = model.Price,
                CategoryId = model.CategoryId,
                Quantity = model.Quantity
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var component = await repository.GetByIdAsync(id);

            await repository.RemoveAsync(component);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id, string componentName, int categoryId)
        {
            var component = await repository.GetByIdAsync(id);

            var model = new EditViewModel
            {
                Id = id,
                ComponentName = componentName,
                Price = component.Price,
                Quantity = component.Quantity,
                CategoryId = categoryId
                
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var component = await repository.GetByIdAsync(model.Id);

                component.CategoryId = model.CategoryId;
                component.Price = model.Price;
                component.Quantity = model.Quantity;

                await repository.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
