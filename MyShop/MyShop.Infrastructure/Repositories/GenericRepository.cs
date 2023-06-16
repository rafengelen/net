using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private ShoppingContext _context;
        private DbSet<T> table = null;

        public GenericRepository(ShoppingContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public virtual T Add(T obj)
        {
            table.Add(obj);
            return obj;
        }

        public virtual T Update(T obj)
        {
            table.Update(obj);
            return obj;
        }

        public virtual T Get(int id)
        {
            var obj = table.Find(id);
            return obj;
        }

        public virtual IEnumerable<T> All()
        {
            return table.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


        public IEnumerable<T> Find(
         Expression<Func<T, bool>> filter = null,
         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
         params Expression<Func<T, object>>[] includes)

        {
            IQueryable<T> query = table;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        // ASYNC METHODS
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }


        public async Task<T> GetByIDAsync(int id)
        {
            return await table.FindAsync(id);
        }


        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
                                                    IOrderedQueryable<T>> orderBy = null,
                                                    params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
                                                  IOrderedQueryable<T>> orderBy = null,
                                                  params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }


        public void Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

    }
}
