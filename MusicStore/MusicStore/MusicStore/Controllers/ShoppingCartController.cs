using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly StoreContext _context;
        private HttpContext httpContext;

        public ShoppingCartController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            var shoppingCart = new ShoppingCart(HttpContext, _context);
            var cartItems = shoppingCart.GetCartItems();
            return View(cartItems);
        }
        public IActionResult AddToCart(int id)
        {
            var shoppingCart = new ShoppingCart(HttpContext, _context);
            var album = _context.Albums.SingleOrDefault(a=>a.AlbumID== id);
            shoppingCart.AddToCart(album);
            return RedirectToAction("Index");
            
        }
        public IActionResult RemoveFromCart(int id)
        {
            var shoppingCart = new ShoppingCart(HttpContext, _context);
            shoppingCart.RemoveFromCart(id);
            return RedirectToAction("Index");
        }
        public IActionResult AddOne(int id)
        {
            var shoppingCart = new ShoppingCart(HttpContext, _context);
            shoppingCart.AddOneToCart(id);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveOne(int id)
        {
            var shoppingCart = new ShoppingCart(HttpContext, _context);
            shoppingCart.RemoveOneFromCart(id);
            return RedirectToAction("Index");
        }
    }
}
