using Core.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        public BaseRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria)
        {
            IQueryable<T> query = _context.Set<T>();
            return await query.SingleOrDefaultAsync(criteria);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> include)
        {
            var query = _context.Set<T>().Where(criteria);
            query = query.Include(include);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> ListAllAsync(Expression<Func<T, object>> include)
        {
            return await _context.Set<T>().Include(include).ToListAsync();
        }

        public async Task<List<T>> ListAllAsync(Expression<Func<T, bool>> criteria)
        {
            return await _context.Set<T>().Where(criteria).ToListAsync();
        }
   
        public async Task<List<T>> ListAllAsync(Expression<Func<T, bool>> criteria
            , Expression<Func<T, bool>> secondCriteria)
        {
            var query = _context.Set<T>().Where(criteria);
            query = query.Where(secondCriteria);

            return await query.ToListAsync();
        }

        public async Task<List<T>> ListAllAsync(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> include)
        {
            var query = _context.Set<T>().Where(criteria);
            query = query.Include(include);

            return await query.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public bool Delete(T entity)
        {
            var result = _context.Remove(entity);
            if (result == null)
            {
                return false;
            }
            return true;
        }         
    }
}
