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
        public FoodRepository(IDietDatabaseSettings settings, IDBManager dbConnection)
        {
            //to check if DI....
            var client = dbConnection.getDatabase();
            var database = client.GetDatabase(settings.DatabaseName);
            foodCollection = database.GetCollection<Food>(settings.FoodCollectionName);
        }

        public async Task<string> AddAsync(Food food)
        {
            await foodCollection.InsertOneAsync(food);
            //return id

            return "";

        }

        public async Task<bool> DeleteAsync(string code)
        {
            FilterDefinition<Food> filter = Builders<Food>.Filter.Eq("Code", code);
            await foodCollection.DeleteOneAsync(filter);
            //return task
            return true;

        }

        public async Task<List<Food>> GetAllAsync()
        {
            //var foodList = foodCollection.Find(new BsonDocument()).ToList();
            return await foodCollection.GetAsync();
            //return firstDocument;
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
