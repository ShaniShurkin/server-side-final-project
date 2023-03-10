using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FoodRepository : IFoodRepository
    {
         private readonly IMongoCollection<Food> _foodsCollection;

    public FoodRepository(
        IOptions<DietDatabaseSettings> dietDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            dietDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            dietDatabaseSettings.Value.DatabaseName);

        _booksCollection = mongoDatabase.GetCollection<Food>(
            dietDatabaseSettings.Value.FoodCollectionName);
    }


        public Task<string> AddAsync(Food objectToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Food>> GetAllAsync()
        {
            await _foodsCollection.Find(_ => true).ToListAsync();
        }

        public Task<Food> GetSingleAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatAsync(Food objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
