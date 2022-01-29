using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RadioComponents.Domain;
using RadioComponents.Domain.Entities;
using RadioComponents.Domain.Models;
using RadioComponents.Models;
using RadioComponents.Services.Queries;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ComponentsQueries componentsQueries;

        public HomeController(ILogger<HomeController> logger, ComponentsQueries componentsQueries)
        {
            _logger = logger;
            this.componentsQueries = componentsQueries;
        }

        public async Task<IActionResult> Index(string componName, ComponType? componType)
        {
            var allcomponents = await componentsQueries.GetAllComponents(componName, componType);

            return View(allcomponents);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
