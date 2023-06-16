using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System.Linq;

namespace MyShop.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        private readonly ShoppingContext _context;
        public CustomerRepository(ShoppingContext context) : base(context)
        {
            _context = context;
        }

        public override Customer Update(Customer entity)
        {
            var customer = _context.Customers
                .Single(c => c.CustomerID == entity.CustomerID);

            customer.Name = entity.Name;
            customer.City = entity.City;
            customer.PostalCode = entity.PostalCode;
            customer.ShippingAddress = entity.ShippingAddress;
            customer.Country = entity.Country;
    
            return base.Update(customer);
        }
    }
}
