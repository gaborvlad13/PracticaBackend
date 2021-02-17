using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeachersPageBackend.Domain;
using TeachersPageBackend.Repositories.Materii;

namespace TeachersPageBackend.Services.Materii
{
    public class MateriiService : IMateriiService
    {
        private readonly IMateriiRepository _materiiRepository;

        public MateriiService(IMateriiRepository materiiRepository)
        {
            _materiiRepository = materiiRepository;
        }
        public async Task Add(Materie model)
        {
            await _materiiRepository.AddAsync(model);
        }

        public async Task<List<Materie>> GetAll()
        {
            return await _materiiRepository.GetAllAsync();
        }

        public async Task<bool> Remove(Guid id)
        {
            return await _materiiRepository.RemoveAsync(id);

        }

        public async Task<bool> Update(Materie model)
        {
            return await _materiiRepository.UpdateAsync(model);
        }
    }
}
