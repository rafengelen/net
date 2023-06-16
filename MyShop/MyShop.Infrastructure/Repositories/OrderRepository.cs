using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System.Linq;

namespace MyShop.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        private readonly ShoppingContext _context;
        public OrderRepository(ShoppingContext context) : base(context)
        {
            _context = context;
        }

        public override Order Update(Order entity)
        {
            var order = _context.Orders
                .Single(o => o.OrderID == entity.OrderID);

            order.OrderDate = DateTime.Now;
            order.Orderlines = entity.Orderlines;

            return base.Update(order);
        }

        public override IEnumerable<Order> All()
        {
            var allOrders =  _context.Orders
                .Include(order => order.Customer)
                .Include(order => order.Orderlines)
                .ThenInclude(orderline => orderline.Product)
                .ToList();

            return allOrders;
        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Orderlines)
                .ThenInclude(p => p.Product)
                .Include(c => c.Customer)
                .ToListAsync();
        }
    }
}
