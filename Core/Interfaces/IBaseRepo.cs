using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IBaseRepo<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>> criteria);
        Task<T> FindAsync(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> include);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAllAsync(Expression<Func<T, object>> include);
        Task<List<T>> ListAllAsync(Expression<Func<T, bool>> criteria);
        Task<List<T>> ListAllAsync(Expression<Func<T, bool>> criteria, Expression<Func<T, bool>> secondCriteria);
        Task<List<T>> ListAllAsync(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> include);

        Task AddAsync(T entity);

        void Update(T entity);
        bool Delete(T entity);
    }
}
