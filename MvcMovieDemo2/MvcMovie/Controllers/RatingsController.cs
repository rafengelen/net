using System.Linq;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using MvcMovie.DAL;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class RatingsController : Controller
    {
        //private IRepository<Rating> ratingRepository;
        private IUnitOfWork _uow;

        public RatingsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Ratings/List
        public IActionResult List()
        {
            var ratings = _uow.RatingRepository.GetAll().OrderBy(r => r.Name);
           
            return View(ratings);
        }

        // GET: Ratings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ratings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RatingID,Code,Name")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                _uow.RatingRepository.Insert(rating);
                _uow.Save();
                return RedirectToAction("List");
            }
            return View(rating);
        }

        // GET: Ratings/Edit/5
        public IActionResult Edit(int id)
        {
            var rating = _uow.RatingRepository.GetByID(id);

            return View(rating);
        }

        // POST: Ratings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("RatingID,Code,Name")] Rating rating)
        {
			if (ModelState.IsValid)
            {
                try
                {
                    _uow.RatingRepository.Update(rating);
                    _uow.Save();
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction("List");
            }
            return View(rating);
        }

        // GET: Ratings/Delete/5
        public IActionResult Delete(int id)
        {
            _uow.RatingRepository.Delete(id);
            _uow.Save();
            return RedirectToAction("List");
        }

    }
}
