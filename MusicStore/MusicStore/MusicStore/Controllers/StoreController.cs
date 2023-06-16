using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreContext _context;

        public StoreController(StoreContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListGenres()
        {
            return View(await _context.Genres.OrderBy(g=>g.Name).ToListAsync());
            
        }
        public async Task<IActionResult> ListAlbums(int id)
        {

            return View(await _context.Albums.OrderBy(g => g.Title).Where(g=>g.GenreID==id).ToListAsync());

        }
        public async Task<IActionResult> Details(int id)
        {

            return View(await _context.Albums.Include(a=>a.Genre).Include(a=>a.Artist).SingleAsync(a=>a.AlbumID==id));
        }
    }
}
