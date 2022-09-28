using Core.Interfaces;
using Core.Models;
using Infrastructure.Context;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IBaseRepo<Department> Departments { get; private set; }
        public IBaseRepo<Employee> Employees { get; private set; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Departments = new BaseRepo<Department>(_context);
            Employees = new BaseRepo<Employee>(_context);
        }       

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
