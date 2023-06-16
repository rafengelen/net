using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;

namespace MyShop.Infrastructure
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext() { } 

        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Orderline> Orderlines { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Orderline>().ToTable("Orderline");
            modelBuilder.Entity<Order>().ToTable("Order");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-MyShop.Web-650c31e9-7900-4378-9421-6a05382e2e51;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
