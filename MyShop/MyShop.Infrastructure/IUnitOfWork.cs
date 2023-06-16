using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure
{
    public interface IUnitOfWork
    {
        Repositories.IRepository<Customer> CustomerRepository { get; }
        Repositories.IRepository<Order> OrderRepository { get; }
        Repositories.IRepository<Product> ProductRepository { get; }

        void SaveChanges();

        // ASYNC
        Task SaveAsync();
    }
}
