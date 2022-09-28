using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IBaseRepo<Department> Departments { get; }
        IBaseRepo<Employee> Employees { get; }

        Task<int> CompleteAsync();
    }
}
