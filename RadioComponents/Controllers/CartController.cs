using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadioComponents.Domain;
using RadioComponents.Domain.Entities;
using RadioComponents.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RadioComponents.Controllers
{
    public class CartController : Controller
    {
        private readonly IRepository<Component> repository;
        public CartController(IRepository<Component> repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                ViewBag.Cart = cart;
                ViewBag.Total = cart.Sum(item => item.Component.Price * item.Quantity);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int componentId, int componentCount) 
        {
            var comp = await repository.GetByIdAsync(componentId);

            var name = await repository.GetAll()
                  .Where(c => c.Id == componentId)
                  .Select(c => c.Category.Name)
                  .FirstOrDefaultAsync();

            if (SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart") == null)
            {
                List<Cart> cart = new List<Cart>
                {
                    new Cart { Component = comp, ComnpanentId = componentId, Name = name, Price = comp.Price, Quantity = componentCount }
                };
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");

                var element = cart.FirstOrDefault(x => x.ComnpanentId == componentId);
                if (element != null)
                {
                    element.Quantity += componentCount;
                }
                else
                {
                    cart.Add(new Cart { Component = comp, ComnpanentId = componentId, Name = name, Price = comp.Price, Quantity = componentCount });
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            cart.RemoveAt(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToAction("Index");
        }

        private int IsExist(string id)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Component.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        public IActionResult DeleteComponents()
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                int i = 0;
                while (i < cart.Count)
                {
                    cart.RemoveAt(i);
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }
    }
}
