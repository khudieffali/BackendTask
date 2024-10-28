using BackendTask.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BackendTask.Services.Concretes
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _table;
        protected Repository(DbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
             await _table.AddAsync(entity);
             _context.SaveChanges();
              return entity;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
        {
            var query = _table.AsQueryable();
            if (true)
            {
                query = query.AsNoTracking();
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query;
        }
    }
}
