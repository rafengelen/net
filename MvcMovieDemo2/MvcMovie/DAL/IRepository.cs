using System.Linq.Expressions;

namespace MvcMovie.DAL
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIDAsync(int id);

        void Insert(T obj);
        void Delete(int id);
        void Update(T obj);
        //void Save();
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes
        );
    }
}
