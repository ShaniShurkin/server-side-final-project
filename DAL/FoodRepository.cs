using DAL.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DAL
{
    public class FoodRepository : IFoodRepository
    {
        private IMongoCollection<Food> foodCollection;
        public FoodRepository(IDietDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            foodsCollection = database.GetCollection<Food>(settings.FoodCollectionName);
        
        }
        
        public Task<string> AddAsync(Food objectToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Food>> GetAllAsync()
        {
            var firstDocument = foodsCollection.Find(new BsonDocument()).ToList();
            return firstDocument;
            //var documents = await foodsCollection.Find().ToListAsync();

            //await return foodsCollection.Find(_ => true).ToListAsync();
           // await return foodsCollection.Find().ToListAsync();
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
