using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersPageBackend.Repositories
{
    public interface IRepository<T> where T: class
    {
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> RemoveAsync(Guid id);
    }
}
