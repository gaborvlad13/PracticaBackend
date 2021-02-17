using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersPageBackend.Services
{
    public interface IService<T>
    {
        Task<List<T>> GetAll();

        Task Add(T model);

        Task<bool> Update(T model);

        Task<bool> Remove(Guid id);
    }
}
