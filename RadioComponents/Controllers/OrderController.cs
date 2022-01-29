using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RadioComponents.Domain;
using RadioComponents.Domain.Entities;
using RadioComponents.Domain.Models;
using RadioComponents.Models.Order;
using RadioComponents.Services;
using RadioComponents.Services.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RadioComponents.Controllers
{
    public class OrderController : Controller
    {
        private readonly IRepository<Order> repositoryOrder;
        private readonly OrderQueries orderQueries;
        private readonly UserManager<User> userManager;
        private readonly IRepository<Component> repositoryComponent;

        public OrderController(IRepository<Order> repositoryOrder, OrderQueries orderQueries, UserManager<User> userManager, IRepository<Component> repositoryComponent)
        {
            this.repositoryOrder = repositoryOrder;
            this.orderQueries = orderQueries;
            this.userManager = userManager;
            this.repositoryComponent = repositoryComponent;
        }

        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Index()
        {
            var orders = await repositoryOrder.GetAll().ToListAsync();

            var model = new ListOrderViewModel
            {
                AllOrders = orders
            };
            //var allorders = await orderQueries.GetAllOrders();


            return View(model);
        }

        public async Task<IActionResult> Ordering()
        {
            var user = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var model = new OrderingViewModel
            {
                Email = user.Email
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Ordering(OrderingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");

                int totalPrice = cart.Sum(item => item.Component.Price * item.Quantity);

                foreach (var el in cart)
                {
                    var comp = await repositoryComponent.GetByIdAsync(el.Component.Id);
                    comp.Quantity -= el.Quantity;
                }
                var jConfig = JsonSerializer.Serialize(cart);

                var order = new Order
                {
                    ClientName = model.ClientName,
                    Email = model.Email,
                    OrderTime = DateTime.Now,
                    Price = totalPrice,
                    Phone = model.Phone,
                    Status = OrderStatus.NotGiven,
                    OrderInfoString = jConfig
                };
                await repositoryOrder.AddAsync(order);

                int i = 0;
                while (i < cart.Count)
                {
                    cart.RemoveAt(i);
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

                return RedirectToAction("MyOrders");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var order = await repositoryOrder.GetByIdAsync(id);

            var listcomponents = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cart>>(order.OrderInfoString);

            foreach(var comp in listcomponents)
            {
                var component = await repositoryComponent.GetByIdAsync(comp.Component.Id);
                component.Quantity += comp.Quantity;
            }
            await repositoryOrder.RemoveAsync(order);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SwitchStatus(int id)
        {
            var order = await repositoryOrder.GetByIdAsync(id);

            if (order.Status == OrderStatus.NotGiven)
            {
                order.Status = OrderStatus.Given;
            }
            await repositoryOrder.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MyOrders()
        {
            var user = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            var orders = await repositoryOrder.GetAll()
                .Where(x => x.Email == user.Email)
                .ToListAsync();

            var model = new ListMyOrderViewModel {
                AllOrders = orders
            };
            return View(model);
        }
    }
}
