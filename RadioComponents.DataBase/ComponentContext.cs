using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RadioComponents.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RadioComponents.DataBase
{
    public class ComponentContext : IdentityDbContext<User>
    {
        public ComponentContext(DbContextOptions<ComponentContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Component> Components { get; set; }
        public DbSet<Сategory> Categories { get; set; }
        public override DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        //public DbSet<CartItem> ShoppingCartItems { get; set; }
    }
}
