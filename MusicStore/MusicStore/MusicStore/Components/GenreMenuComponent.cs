using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using System.Xml.Linq;

namespace MusicStore.Components
{
    [ViewComponent(Name = "GenreMenu")]
    public class GenreMenuComponent : ViewComponent
    {
        private readonly StoreContext _context;

        public GenreMenuComponent(StoreContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = _context.Genres.Take(8).ToList();
            //ViewData["Genres"] = genres;
            return View(genres);
        }
    }
}
