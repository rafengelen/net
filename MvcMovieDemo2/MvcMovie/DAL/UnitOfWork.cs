using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private MovieContext _context;
        private IRepository<Movie> movieRepository;
        private IRepository<Rating> ratingRepository;
        public UnitOfWork(MovieContext context)
        {
            _context = context;
        }
        public IRepository<Movie> MovieRepository
        {
            //Check nakijken of repository al bestaat, als deze niet bestaat, eerst aanmaken
            get
            {
                if (movieRepository == null)
                {
                    movieRepository = new GenericRepository<Movie>(_context);
                }
                return movieRepository;
            }
        }
        public IRepository<Rating> RatingRepository
        {
            //Beide repositories zijn gemaakt met dezelfde dbcontext instance
            get
            {
                if (ratingRepository == null)
                {
                    ratingRepository = new GenericRepository<Rating>(_context);
                }
                return ratingRepository;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
