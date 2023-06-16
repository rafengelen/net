using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;

namespace MyShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private IUnitOfWork _uow;

        public ProductsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET /api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _uow.ProductRepository.All();

            return products.ToList();
        }

        // GET /api/products{id}
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _uow.ProductRepository.Get(id);

            if (product == null) 
            {
                return NotFound();
            }

            return product;
        }

          // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            _uow.ProductRepository.Add(product);

            _uow.SaveChanges();

            return CreatedAtAction("GetProduct", new { id = product.ProductID }, product);
        }

    }
}
