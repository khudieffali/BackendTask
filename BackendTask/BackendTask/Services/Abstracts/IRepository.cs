using System.Linq.Expressions;

namespace BackendTask.Services.Abstracts
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
        Task<T> Add(T entity);
    }
}
