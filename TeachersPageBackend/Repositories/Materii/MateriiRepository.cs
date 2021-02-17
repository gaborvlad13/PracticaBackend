using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeachersPageBackend.Domain;
using TeachersPageBackend.Settings;

namespace TeachersPageBackend.Repositories.Materii
{
    public class MateriiRepository : IMateriiRepository
    {
        private readonly IMongoCollection<Materie> _materii;

        public MateriiRepository(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _materii = database.GetCollection<Materie>(settings.MateriiCollectionName);

        }
        public async Task AddAsync(Materie entity)
        {
            await _materii.InsertOneAsync(entity);
        }

        public async Task<List<Materie>> GetAllAsync()
        {
            var materii = await _materii.FindAsync(filter => true);
            return materii.ToList();
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var result = await _materii.DeleteOneAsync(materie => materie.Id.Equals(id));
            if (!result.IsAcknowledged || result.DeletedCount == 0)
                return false;
            return true;
        }

        public async Task<bool> UpdateAsync(Materie entity)
        {
            var result = await _materii.ReplaceOneAsync(materie => materie.Id.Equals(entity.Id), entity);
            if (!result.IsAcknowledged || result.ModifiedCount == 0)
                return false;
            return true;
        }
    }
}
