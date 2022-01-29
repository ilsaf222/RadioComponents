using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RadioComponents.Domain;
using RadioComponents.Domain.Entities;
using RadioComponents.Models;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace RadioComponents.Controllers
{
    public class CategoryGenericController<TConfig> : Controller
    {
        private readonly IRepository<Сategory> repository;
        private IWebHostEnvironment _hostingEnvironment;
        public CategoryGenericController(IRepository<Сategory> repository, IWebHostEnvironment environment)
        {
            this.repository = repository;
            _hostingEnvironment = environment;
        }

        public IActionResult List()
        {
            return RedirectToAction("List", "Category");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel<TConfig> model)
        {
            if (ModelState.IsValid)
            {
                if (model.UploadedFile != null) //D:\asp.net\RadioComponents\RadioComponents\wwwroot\image\
                {
                    string uploads = Path.Combine(_hostingEnvironment.WebRootPath, @"D:\asp.net\RadioComponents\RadioComponents\wwwroot\image\");

                    string filePath = Path.Combine(uploads, model.UploadedFile.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.UploadedFile.CopyToAsync(fileStream);
                    }
                }
                string imageUrl = $"/image/{model.UploadedFile.FileName}";

                var jConfig = JObject.FromObject(model.Configuration);
                await repository.AddAsync(new Сategory()
                {
                    Image = imageUrl,
                    Name = model.Name,
                    ComponentsInfoString = jConfig.ToString(),
                    Type = model.Type
                });

                return RedirectToAction("List");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var сategory = await repository.GetByIdAsync(id);

            if (сategory != null)
            {
                var categoryString = JsonConvert.DeserializeObject<TConfig>(сategory.ComponentsInfoString);

                return View(new EditCategoryViewModel<TConfig>()
                {
                    Id = id,
                    Name = сategory.Name,
                    Configuration = categoryString
                });
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryViewModel<TConfig> model)
        {
            if (ModelState.IsValid)
            {
                var jConfig = JObject.FromObject(model.Configuration);

                var category = await repository.GetByIdAsync(model.Id);
                category.Name = model.Name;
                category.ComponentsInfoString = jConfig.ToString();

                await repository.SaveChangesAsync();

                return RedirectToAction("List");
            }

            return View();
        }

        public async Task<IActionResult> Info(int id)
        {
            var сategory = await repository.GetByIdAsync(id);

            if (сategory != null)
            {
                var categoryString = JsonConvert.DeserializeObject<TConfig>(сategory.ComponentsInfoString);

                return View(new ListInfoCategoryViewModel<TConfig>()
                {
                    Name = сategory.Name,
                    Type = сategory.Type,
                    Configuration = categoryString
                });
            }
            return View();
        }
    }
}


//var fileName = Path.GetFileName(model.UploadedFile.FileName);
//var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\image", fileName);
//using (var fileStream = new FileStream(filePath, FileMode.Create))
//{
//    await model.UploadedFile.CopyToAsync(fileStream);
//}

//Bitmap b1 = new Bitmap(model.UploadedFile.FileName);
//Bitmap b2 = new Bitmap(b1, new Size(846, 800));