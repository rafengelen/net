using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        T Add(T obj);
        T Update(T obj);
        T Get(int id);
        IEnumerable<T> All();
        void SaveChanges();

        IEnumerable<T> Find(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           params Expression<Func<T, object>>[] includes);


        // ASYNC
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIDAsync(int id);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
                                                    IOrderedQueryable<T>> orderBy = null,
                                                    params Expression<Func<T, object>>[] includes);

        // Delete
        void Delete(int id);

    }
}
