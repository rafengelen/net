using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShoppingContext _context;

        public UnitOfWork(ShoppingContext context)
        {
            _context = context;
        }

        public IRepository<Customer> CustomerRepository => new CustomerRepository(_context);
        public IRepository<Order> OrderRepository => new OrderRepository(_context);
        public IRepository<Product> ProductRepository => new ProductRepository(_context);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        // ASYNC
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
