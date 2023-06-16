using MyShop.Domain.Models;

namespace MyShop.Web.Models.ViewModels
{
    public class ProductsAndCustomersVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
